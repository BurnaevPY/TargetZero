using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.WebApplication.ModelFilters;
using TargetZero.WebApplication.Models;

namespace TargetZero.WebApplication.Queries
{
    public class PostgresQueries : IQueries
    {
        private readonly string _connectionString;
        public PostgresQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        private string GetFilterString(
            int? innovationId, 
            int? considerationGroupId, int? nonConsiderationGroupId,
            int? categoryId, int? filialId, int? innovationStatusId,
            string author,
            bool? hasResolution, bool? hasConsideration)
        {
            var filterString = "i.\"IsActual\"";

            if (innovationId.HasValue)
            {
                filterString += $" and i.\"Id\" = {innovationId.Value} ";
                //return filterString;
            }

            if (categoryId.HasValue)
            {
                filterString += $" and i.\"CategoryId\" = {categoryId.Value} ";
            }

            if (filialId.HasValue)
            {
                filterString += $" and i.\"FilialId\" = {filialId.Value} ";
            }

            if (innovationStatusId.HasValue)
            {
                if (innovationStatusId == InnovationStatusFilter.Reworked)
                {
                    filterString += $" and w.\"InnovationStatusId\" = {InnovationStatus.Rework.Id} and i.\"InnovationStatusId\" = {InnovationStatus.Consideration.Id} ";
                }
                else
                {
                    filterString += $" and i.\"InnovationStatusId\" = {innovationStatusId.Value} ";
                }
                
            }

            if (hasResolution.HasValue)
            {
                if (hasResolution.Value)
                {
                    filterString += $" and l.\"ResolutionCount\" > 0 ";
                }
                else
                {
                    filterString += $" and l.\"ResolutionCount\" = 0 ";
                }
            }

            if (hasConsideration.HasValue)
            {
                if (hasConsideration.Value)
                {
                    filterString += $" and c.\"ConsiderationCount\" > 0 ";
                }
                else
                {
                    filterString += $" and c.\"ConsiderationCount\" = 0 ";
                }
            }

            if (considerationGroupId.HasValue)
            {
                filterString += $" and c.\"ConsiderationGroupCount\" > 0 "; 
            }

            if (nonConsiderationGroupId.HasValue)
            {
                filterString += $" and c.\"NonConsiderationGroupCount\" is null ";
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                filterString += $" and i.\"Author\" = '{author}' ";
            }

            return filterString;
        }

        public async Task<int> GetInnovationCount(
            int? innovationId, 
            int? considerationGroupId, int? nonConsiderationGroupId,
            int? categoryId, int? filialId, int? innovationStatusId, 
            string author,
            bool? hasResolution, bool? hasConsideration)
        {
            var filterString = GetFilterString(
                innovationId, 
                considerationGroupId, nonConsiderationGroupId, 
                categoryId, filialId, innovationStatusId,
                author,
                hasResolution, hasConsideration);

            var sql = @"
                --select count(distinct i.""Id"")
                select count(i.""Id"") 
                from ""Innovations"" i
                    join ""Categories"" r on r.""Id"" = i.""CategoryId""
                    join ""Filials"" f on f.""Id"" = i.""FilialId""
                    join ""InnovationStatuses"" s on s.""Id"" = i.""InnovationStatusId""
                    join lateral (
                        select count(*) ""ConsiderationCount"", 
                            sum(case when ""ConsiderationGroupId"" = @considerationGroupId then 1 else 0 end) ""ConsiderationGroupCount"" ,
                            sum(case when ""ConsiderationGroupId"" = @nonConsiderationGroupId then 1 else null end) ""NonConsiderationGroupCount""  
                        from ""Considerations"" where ""InnovationId"" = i.""Id"") as c on true 
                    join lateral (
                        select count(*) ""ResolutionCount"" 
                        from ""Resolutions"" where ""InnovationId"" = i.""Id"") as l on true 
                    left join lateral ( 
                        select distinct on(""InnovationId"") ""Id"", ""InnovationStatusId"" 
                        from ""Resolutions"" where ""InnovationId"" = i.""Id"" 
                        order by ""InnovationId"", ""Id"" desc ) as w on true 
                where " + filterString;

            using var connection = new Npgsql.NpgsqlConnection(_connectionString);
            connection.Open();
            var count = await connection.ExecuteScalarAsync<int>(sql, new { considerationGroupId, nonConsiderationGroupId });

            return count;
        }

        public async Task<IEnumerable<InnovationItemModel>> GetInnovationList(
            int? innovationId,
            int? considerationGroupId, int? nonConsiderationGroupId, 
            int? categoryId, int? filialId, int? innovationStatusId,
            string author,
            bool? hasResolution, bool? hasConsideration, 
            int skip, int take, InnovationSortState sortOrder)
        {
            var orderString = sortOrder switch
            {
                InnovationSortState.CreateTimeAsc => @"order by i.""CreateTime"" asc, i.""Id""",
                InnovationSortState.CreateTimeDesc => @"order by i.""CreateTime"" desc, i.""Id""",
                InnovationSortState.TotalAsc => @"order by c.""ConsiderationCount"" asc, i.""Id""",
                InnovationSortState.TotalDesc => @"order by c.""ConsiderationCount"" desc, i.""Id""",
                InnovationSortState.IdAsc => @"order by i.""Id"" asc",
                InnovationSortState.IdDesc => @"order by i.""Id"" desc",
                _ => @" order by i.""Id"" "
            };


            var filterString = GetFilterString(
                innovationId, 
                considerationGroupId, nonConsiderationGroupId,
                categoryId, filialId, innovationStatusId,
                author,
                hasResolution, hasConsideration);

            var sql = @"
                select i.""Id"", i.""CreateTime"", i.""Author"", 
                    i.""Description"" , i.""CurrentState"" , i.""TargetState"" , i.""Reason"", i.""InnovationStatusId"",  
                    r.""Name"" as ""CategoryName"", f.""Name"" as ""FilialName"", s.""Description""  as ""InnovationStatusDescription"", 
                    c.""ConsiderationCount"", c.""ConsiderationGroupCount"", l.""ResolutionCount"" 
                from ""Innovations"" i
                    join ""Categories"" r on r.""Id"" = i.""CategoryId""
                    join ""Filials"" f on f.""Id"" = i.""FilialId""
                    join ""InnovationStatuses"" s on s.""Id"" = i.""InnovationStatusId""
                    join lateral (
                        select count(*) ""ConsiderationCount"", 
                            sum(case when ""ConsiderationGroupId"" = @considerationGroupId then 1 else 0 end) ""ConsiderationGroupCount"" ,
                            sum(case when ""ConsiderationGroupId"" = @nonConsiderationGroupId then 1 else null end) ""NonConsiderationGroupCount""  
                        from ""Considerations"" where ""InnovationId"" = i.""Id"") as c on true 
                    join lateral (
                        select count(*) ""ResolutionCount"" 
                        from ""Resolutions"" where ""InnovationId"" = i.""Id"") as l on true 
                    left join lateral ( 
                        select distinct on(""InnovationId"") ""Id"", ""InnovationStatusId"" 
                        from ""Resolutions"" where ""InnovationId"" = i.""Id"" 
                        order by ""InnovationId"", ""Id"" desc ) as w on true
                where " + filterString + " " + orderString + @" limit @take offset @skip";

            using var connection = new Npgsql.NpgsqlConnection(_connectionString);
            connection.Open();
            var model = await connection.QueryAsync<InnovationItemModel>(sql, new { take, skip, considerationGroupId, nonConsiderationGroupId });

            return model;
        }


        public async Task<IEnumerable<ReportInnovationItemModel>> GetInnovationReportList(
            int? innovationId, 
            int? considerationGroupId, int? nonConsiderationGroupId, 
            int? categoryId, int? filialId, int? innovationStatusId,
            string author,
            bool? hasResolution, bool? hasConsideration)
        {
            var filterString = GetFilterString(
                innovationId, 
                considerationGroupId, nonConsiderationGroupId,
                categoryId, filialId, innovationStatusId, 
                author,
                hasResolution, hasConsideration);

            var sql = @"
                select i.""Id"", i.""CreateTime"", i.""Author"", 
                    i.""Description"" , i.""CurrentState"" , i.""TargetState"" , i.""Reason"", i.""InnovationStatusId"",  
                    r.""Name"" as ""CategoryName"", f.""Name"" as ""FilialName"", s.""Description""  as ""InnovationStatusDescription"", 
                    c.""ConsiderationCount"", c.""ConsiderationGroupCount"", 
                    l.""ResolutionCount"", w.""LastResolutionContent"", w.""LastResolutionCreateTime"",
                    gr.""ConsiderationGroup1"", gr.""ConsiderationGroup2"", gr.""ConsiderationGroup3"", gr.""ConsiderationGroup4"", gr.""ConsiderationGroup5"", gr.""ConsiderationGroup6"", gr.""ConsiderationGroup7""
                from ""Innovations"" i
                    join ""Categories"" r on r.""Id"" = i.""CategoryId""
                    join ""Filials"" f on f.""Id"" = i.""FilialId""
                    join ""InnovationStatuses"" s on s.""Id"" = i.""InnovationStatusId""
                    join lateral (
                        select count(*) ""ConsiderationCount"", 
                            sum(case when ""ConsiderationGroupId"" = @considerationGroupId then 1 else 0 end) ""ConsiderationGroupCount"" ,
                            sum(case when ""ConsiderationGroupId"" = @nonConsiderationGroupId then 1 else null end) ""NonConsiderationGroupCount""
                        from ""Considerations"" where ""InnovationId"" = i.""Id"") as c on true 
                    join lateral (
                        select count(*) ""ResolutionCount""
                        from ""Resolutions"" where ""InnovationId"" = i.""Id"") as l on true 
                    left join lateral ( 
                        select distinct on(""InnovationId"") ""Id"", ""InnovationStatusId"", ""Content"" as ""LastResolutionContent"", ""CreateTime"" as ""LastResolutionCreateTime"" 
                        from ""Resolutions"" where ""InnovationId"" = i.""Id"" 
                        order by ""InnovationId"", ""Id"" desc ) as w on true 
                    left join lateral (
                        select  ""InnovationId"" ,
                            max( case when ""ConsiderationGroupId"" = 1 then ""Content"" else null end) as ""ConsiderationGroup1"", 
    	                    max( case when ""ConsiderationGroupId"" = 2 then ""Content"" else null end) as ""ConsiderationGroup2"", 
    	                    max( case when ""ConsiderationGroupId"" = 3 then ""Content"" else null end) as ""ConsiderationGroup3"", 
    	                    max( case when ""ConsiderationGroupId"" = 4 then ""Content"" else null end) as ""ConsiderationGroup4"", 
    	                    max( case when ""ConsiderationGroupId"" = 5 then ""Content"" else null end) as ""ConsiderationGroup5"", 
    	                    max( case when ""ConsiderationGroupId"" = 6 then ""Content"" else null end) as ""ConsiderationGroup6"", 
    	                    max( case when ""ConsiderationGroupId"" = 7 then ""Content"" else null end) as ""ConsiderationGroup7""
                        from ""Considerations""
                        where ""InnovationId"" = i.""Id""
                        group by ""InnovationId"" ) gr on true 
                where " + filterString + @" 
                order by i.""CreateTime"" desc, i.""Id"" desc";

            using var connection = new Npgsql.NpgsqlConnection(_connectionString);
            connection.Open();
            var model = await connection.QueryAsync<ReportInnovationItemModel>(sql, new { considerationGroupId, nonConsiderationGroupId });

            return model;
        }
    }
}

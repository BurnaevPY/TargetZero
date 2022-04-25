using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.WebApplication.Models;

namespace TargetZero.WebApplication.Queries
{
    public interface IQueries
    {
        Task<IEnumerable<InnovationItemModel>> GetInnovationList(
            int? innovationid,
            int? considerationGroupId, int? nonConsiderationGroupId, 
            int? categoryId, int? filialId, int? innovationStatusId,
            string author,
            bool? hasResolution, bool? hasConsideration,
            int skip, int take, InnovationSortState sortOrder);

        Task<int> GetInnovationCount(
            int? innovationId, 
            int? considerationGroupId, int? nonConsiderationGroupId,
            int? categoryId, int? filialId, int? innovationStatusId, 
            string author,
            bool? hasResolution, bool? hasConsideration);

        Task<IEnumerable<ReportInnovationItemModel>> GetInnovationReportList(
            int? innovationId, 
            int? considerationGroupId, int? nonConsiderationGroupId, 
            int? categoryId, int? filialId, int? innovationStatusId,
            string author,
            bool? hasResolution, bool? hasConsideration);

    }
}

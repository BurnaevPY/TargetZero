using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class UpdateInnovationsWithStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update \"Innovations\" set \"InnovationStatusId\" = 1 where \"InnovationStatusId\" is null ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

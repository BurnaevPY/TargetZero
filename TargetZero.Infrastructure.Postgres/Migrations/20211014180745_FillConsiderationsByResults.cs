using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class FillConsiderationsByResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update \"Considerations\" set \"ConsiderationResultId\" = \"InnovationStatusId\" where \"ConsiderationResultId\" is null ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

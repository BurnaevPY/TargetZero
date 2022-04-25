using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class UpdateInnovationsWithFilils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update \"Innovations\" set \"FilialId\" = 8 where \"FilialId\" is null ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

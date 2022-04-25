using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class InnovationAuthorToLower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update \"Innovations\" set \"Author\" = lower(\"Author\") ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class ChangeInWorkStatusToImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Реализовано", "Implemented" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "В работе", "InWork" });
        }
    }
}

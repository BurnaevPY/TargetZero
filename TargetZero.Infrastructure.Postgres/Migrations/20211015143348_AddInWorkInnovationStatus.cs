using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class AddInWorkInnovationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InnovationStatuses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 6, "В работе", "InWork" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

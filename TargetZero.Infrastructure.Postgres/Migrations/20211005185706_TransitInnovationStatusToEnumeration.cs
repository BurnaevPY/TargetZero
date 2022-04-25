using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class TransitInnovationStatusToEnumeration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InnovationStatuses",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Рассмотрение", "Consideration" });

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Принято", "Accepted" });

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Отклонено", "Rejected" });

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Уточнение", "Clarification" });

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Доработка", "Rework" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "InnovationStatuses");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Рассмотрение");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Принято");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Отклонено");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Уточнение");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Доработка");
        }
    }
}

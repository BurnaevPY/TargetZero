using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class ChangeConsiderationGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 1", "Group1" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 2", "Group2" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 3", "Group3" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 4", "Group4" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 5", "Group5" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 6", "Group6" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа рассмотрения 7", "Group7" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Группа рассмотрения ГРНУ");

            migrationBuilder.InsertData(
                table: "ConsiderationGroups",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 9, "Группа рассмотрения РРНУ", "Group7" },
                    { 10, "Группа рассмотрения МРНУ", "Group7" },
                    { 11, "Группа рассмотрения БПТОиКО", "Group7" },
                    { 12, "Группа рассмотрения ТНМ", "Group7" },
                    { 13, "Группа рассмотрения ВРНПУ", "Group7" },
                    { 14, "Группа рассмотрения ЦПА", "Group7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа филиала", "Filial" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа 1", "Group1" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа 2", "Group2" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа 3", "Group3" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа 4", "Group4" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа 5", "Group5" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Группа 6", "Group6" });

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Группа 7");
        }
    }
}

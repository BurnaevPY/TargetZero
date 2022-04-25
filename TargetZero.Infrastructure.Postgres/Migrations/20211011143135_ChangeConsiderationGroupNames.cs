using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class ChangeConsiderationGroupNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "GrnuGroup");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "RrnuGroup");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "MrnuGroup");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "BptoGroup");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "TnmGroup");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "VrnpuGroup");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "TspaGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Group7");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Group7");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Group7");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Group7");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Group7");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Group7");

            migrationBuilder.UpdateData(
                table: "ConsiderationGroups",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Group7");
        }
    }
}

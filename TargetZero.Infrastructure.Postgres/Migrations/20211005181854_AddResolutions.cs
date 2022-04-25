using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class AddResolutions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Author = table.Column<string>(type: "text", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InnovationStatusId = table.Column<int>(type: "integer", nullable: true),
                    InnovationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resolutions_Innovations_InnovationId",
                        column: x => x.InnovationId,
                        principalTable: "Innovations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resolutions_InnovationStatuses_InnovationStatusId",
                        column: x => x.InnovationStatusId,
                        principalTable: "InnovationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Рассмотрение");

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

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_InnovationId",
                table: "Resolutions",
                column: "InnovationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_InnovationStatusId",
                table: "Resolutions",
                column: "InnovationStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Новый");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Требует уточнения");

            migrationBuilder.UpdateData(
                table: "InnovationStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Требует доработки заявителя");

            migrationBuilder.InsertData(
                table: "InnovationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Требует дополнительного рассмотрения" });
        }
    }
}

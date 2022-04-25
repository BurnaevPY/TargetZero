using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class AddInnovationStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InnovationStatusId",
                table: "Innovations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InnovationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovationStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InnovationStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Новый" },
                    { 2, "Принято" },
                    { 3, "Отклонено" },
                    { 4, "Требует уточнения" },
                    { 5, "Требует доработки заявителя" },
                    { 6, "Требует дополнительного рассмотрения" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Innovations_InnovationStatusId",
                table: "Innovations",
                column: "InnovationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_InnovationStatuses_InnovationStatusId",
                table: "Innovations",
                column: "InnovationStatusId",
                principalTable: "InnovationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_InnovationStatuses_InnovationStatusId",
                table: "Innovations");

            migrationBuilder.DropTable(
                name: "InnovationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Innovations_InnovationStatusId",
                table: "Innovations");

            migrationBuilder.DropColumn(
                name: "InnovationStatusId",
                table: "Innovations");
        }
    }
}

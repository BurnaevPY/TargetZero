using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class AddFilials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilialId",
                table: "Innovations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Filials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filials", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Filials",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Общество" },
                    { 9, "МРНУ" },
                    { 10, "РРНУ" },
                    { 11, "ГРНУ" },
                    { 12, "ТНМ" },
                    { 13, "БПТОиКО" },
                    { 75, "ВРНПУ" },
                    { 79, "ЦПА" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Innovations_FilialId",
                table: "Innovations",
                column: "FilialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_Filials_FilialId",
                table: "Innovations",
                column: "FilialId",
                principalTable: "Filials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_Filials_FilialId",
                table: "Innovations");

            migrationBuilder.DropTable(
                name: "Filials");

            migrationBuilder.DropIndex(
                name: "IX_Innovations_FilialId",
                table: "Innovations");

            migrationBuilder.DropColumn(
                name: "FilialId",
                table: "Innovations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class AddConsiderationResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Considerations_ConsiderationGroups_ConsiderationGroupId",
                table: "Considerations");

            migrationBuilder.AlterColumn<int>(
                name: "ConsiderationGroupId",
                table: "Considerations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsiderationResultId",
                table: "Considerations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Considerations_InnovationId_ConsiderationGroupId",
                table: "Considerations",
                columns: new[] { "InnovationId", "ConsiderationGroupId" });

            migrationBuilder.CreateTable(
                name: "ConsiderationResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiderationResults", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ConsiderationResults",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Вне зоны ответственности", "Consideration" },
                    { 2, "Принято", "Accepted" },
                    { 3, "Отклонено", "Rejected" },
                    { 4, "Уточнение", "Clarification" },
                    { 5, "Доработка", "Rework" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Considerations_ConsiderationResultId",
                table: "Considerations",
                column: "ConsiderationResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Considerations_ConsiderationGroups_ConsiderationGroupId",
                table: "Considerations",
                column: "ConsiderationGroupId",
                principalTable: "ConsiderationGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Considerations_ConsiderationResults_ConsiderationResultId",
                table: "Considerations",
                column: "ConsiderationResultId",
                principalTable: "ConsiderationResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Considerations_Innovations_InnovationId",
                table: "Considerations",
                column: "InnovationId",
                principalTable: "Innovations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Considerations_ConsiderationGroups_ConsiderationGroupId",
                table: "Considerations");

            migrationBuilder.DropForeignKey(
                name: "FK_Considerations_ConsiderationResults_ConsiderationResultId",
                table: "Considerations");

            migrationBuilder.DropForeignKey(
                name: "FK_Considerations_Innovations_InnovationId",
                table: "Considerations");

            migrationBuilder.DropTable(
                name: "ConsiderationResults");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Considerations_InnovationId_ConsiderationGroupId",
                table: "Considerations");

            migrationBuilder.DropIndex(
                name: "IX_Considerations_ConsiderationResultId",
                table: "Considerations");

            migrationBuilder.DropColumn(
                name: "ConsiderationResultId",
                table: "Considerations");

            migrationBuilder.AlterColumn<int>(
                name: "ConsiderationGroupId",
                table: "Considerations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Considerations_ConsiderationGroups_ConsiderationGroupId",
                table: "Considerations",
                column: "ConsiderationGroupId",
                principalTable: "ConsiderationGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

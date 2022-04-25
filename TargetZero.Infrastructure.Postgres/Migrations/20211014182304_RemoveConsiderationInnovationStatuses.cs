using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class RemoveConsiderationInnovationStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Considerations_InnovationStatuses_InnovationStatusId",
                table: "Considerations");

            migrationBuilder.DropIndex(
                name: "IX_Considerations_InnovationStatusId",
                table: "Considerations");

            migrationBuilder.DropColumn(
                name: "InnovationStatusId",
                table: "Considerations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InnovationStatusId",
                table: "Considerations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Considerations_InnovationStatusId",
                table: "Considerations",
                column: "InnovationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Considerations_InnovationStatuses_InnovationStatusId",
                table: "Considerations",
                column: "InnovationStatusId",
                principalTable: "InnovationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

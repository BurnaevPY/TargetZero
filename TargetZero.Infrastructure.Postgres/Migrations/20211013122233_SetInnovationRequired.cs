using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class SetInnovationRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_Categories_CategoryId",
                table: "Innovations");

            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_Filials_FilialId",
                table: "Innovations");

            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_InnovationStatuses_InnovationStatusId",
                table: "Innovations");

            migrationBuilder.AlterColumn<int>(
                name: "InnovationStatusId",
                table: "Innovations",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "FilialId",
                table: "Innovations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Innovations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_Categories_CategoryId",
                table: "Innovations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_Filials_FilialId",
                table: "Innovations",
                column: "FilialId",
                principalTable: "Filials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_InnovationStatuses_InnovationStatusId",
                table: "Innovations",
                column: "InnovationStatusId",
                principalTable: "InnovationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_Categories_CategoryId",
                table: "Innovations");

            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_Filials_FilialId",
                table: "Innovations");

            migrationBuilder.DropForeignKey(
                name: "FK_Innovations_InnovationStatuses_InnovationStatusId",
                table: "Innovations");

            migrationBuilder.AlterColumn<int>(
                name: "InnovationStatusId",
                table: "Innovations",
                type: "integer",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "FilialId",
                table: "Innovations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Innovations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_Categories_CategoryId",
                table: "Innovations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_Filials_FilialId",
                table: "Innovations",
                column: "FilialId",
                principalTable: "Filials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Innovations_InnovationStatuses_InnovationStatusId",
                table: "Innovations",
                column: "InnovationStatusId",
                principalTable: "InnovationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

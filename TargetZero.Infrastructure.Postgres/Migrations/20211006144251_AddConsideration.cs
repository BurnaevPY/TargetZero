using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    public partial class AddConsideration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsiderationGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiderationGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Considerations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    InnovationStatusId = table.Column<int>(type: "integer", nullable: true),
                    ConsiderationGroupId = table.Column<int>(type: "integer", nullable: true),
                    InnovationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Considerations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Considerations_ConsiderationGroups_ConsiderationGroupId",
                        column: x => x.ConsiderationGroupId,
                        principalTable: "ConsiderationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Considerations_InnovationStatuses_InnovationStatusId",
                        column: x => x.InnovationStatusId,
                        principalTable: "InnovationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Considerations_ConsiderationGroupId",
                table: "Considerations",
                column: "ConsiderationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Considerations_InnovationStatusId",
                table: "Considerations",
                column: "InnovationStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Considerations");

            migrationBuilder.DropTable(
                name: "ConsiderationGroups");
        }
    }
}

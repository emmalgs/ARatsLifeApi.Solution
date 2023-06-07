using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLifeApi.Migrations
{
    public partial class UpdateInventoryAndAddJourneyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatId",
                table: "Plotpoints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Journies",
                columns: table => new
                {
                    JourneyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChoiceId = table.Column<int>(type: "int", nullable: false),
                    RatId = table.Column<int>(type: "int", nullable: false),
                    PlotpointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journies", x => x.JourneyId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Plotpoints_RatId",
                table: "Plotpoints",
                column: "RatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plotpoints_Rats_RatId",
                table: "Plotpoints",
                column: "RatId",
                principalTable: "Rats",
                principalColumn: "RatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plotpoints_Rats_RatId",
                table: "Plotpoints");

            migrationBuilder.DropTable(
                name: "Journies");

            migrationBuilder.DropIndex(
                name: "IX_Plotpoints_RatId",
                table: "Plotpoints");

            migrationBuilder.DropColumn(
                name: "RatId",
                table: "Plotpoints");
        }
    }
}

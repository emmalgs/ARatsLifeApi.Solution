using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLifeApi.Migrations
{
    public partial class UpdateRatJourneyField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plotpoints_Rats_RatId",
                table: "Plotpoints");

            migrationBuilder.DropIndex(
                name: "IX_Plotpoints_RatId",
                table: "Plotpoints");

            migrationBuilder.DropColumn(
                name: "RatId",
                table: "Plotpoints");

            migrationBuilder.CreateIndex(
                name: "IX_Journies_RatId",
                table: "Journies",
                column: "RatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Journies_Rats_RatId",
                table: "Journies",
                column: "RatId",
                principalTable: "Rats",
                principalColumn: "RatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journies_Rats_RatId",
                table: "Journies");

            migrationBuilder.DropIndex(
                name: "IX_Journies_RatId",
                table: "Journies");

            migrationBuilder.AddColumn<int>(
                name: "RatId",
                table: "Plotpoints",
                type: "int",
                nullable: true);

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
    }
}

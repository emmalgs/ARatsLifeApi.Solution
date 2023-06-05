using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLifeApi.Migrations
{
    public partial class SeedChoicesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "ChoiceId", "Description", "PlotpointId" },
                values: new object[,]
                {
                    { 1, "Aa", 1 },
                    { 2, "Ab", 1 },
                    { 3, "Ba", 2 },
                    { 4, "Bb", 2 },
                    { 5, "Ca", 3 },
                    { 6, "Cb", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 6);
        }
    }
}

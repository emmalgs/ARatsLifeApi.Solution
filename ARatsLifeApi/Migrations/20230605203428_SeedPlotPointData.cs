using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLifeApi.Migrations
{
    public partial class SeedPlotPointData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plotpoints",
                columns: new[] { "PlotpointId", "Description", "StoryPosition", "Title" },
                values: new object[,]
                {
                    { 1, "plotpoint A", 1, "A" },
                    { 2, "plotpoint B", 2, "B" },
                    { 3, "plotpoint C", 3, "C" },
                    { 4, "plotpoint D", 4, "D" },
                    { 5, "plotpoint E", 5, "E" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plotpoints",
                keyColumn: "PlotpointId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plotpoints",
                keyColumn: "PlotpointId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plotpoints",
                keyColumn: "PlotpointId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plotpoints",
                keyColumn: "PlotpointId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plotpoints",
                keyColumn: "PlotpointId",
                keyValue: 5);
        }
    }
}

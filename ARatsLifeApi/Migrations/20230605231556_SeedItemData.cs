using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLifeApi.Migrations
{
    public partial class SeedItemData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 1,
                column: "HeatLevel",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 3,
                column: "HeatLevel",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 4,
                column: "HeatLevel",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 6,
                column: "HeatLevel",
                value: 35);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "InventoryId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Gucci Belt", 25 },
                    { 2, 2, "Balenciaga Sunglasses", 35 },
                    { 3, 3, "Louis Vuitton Necktie", 15 },
                    { 4, 4, "Hermez Birken Bag", 50 },
                    { 5, 5, "Rolex Wristwatch", 40 },
                    { 6, 6, "White Stilton Gold Cheese", 50 },
                    { 7, 7, "$200, Straight Up", 15 },
                    { 8, 8, "Silver Tiffany Tennis Bracelet", 20 },
                    { 9, 9, "Gucci Slides (Whatever those are)", 10 },
                    { 10, 10, "Versace Platform Heels", 30 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 1,
                column: "HeatLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 3,
                column: "HeatLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 4,
                column: "HeatLevel",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "ChoiceId",
                keyValue: 6,
                column: "HeatLevel",
                value: 0);
        }
    }
}

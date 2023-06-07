using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLifeApi.Migrations
{
    public partial class UpdateInventoryAssociationWithRatandItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Rats");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_RatId",
                table: "Inventories",
                column: "RatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_ItemId",
                table: "Inventories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Rats_RatId",
                table: "Inventories",
                column: "RatId",
                principalTable: "Rats",
                principalColumn: "RatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_ItemId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Rats_RatId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ItemId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_RatId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Rats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1,
                column: "InventoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2,
                column: "InventoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3,
                column: "InventoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4,
                column: "InventoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5,
                column: "InventoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6,
                column: "InventoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7,
                column: "InventoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8,
                column: "InventoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9,
                column: "InventoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10,
                column: "InventoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Rats",
                keyColumn: "RatId",
                keyValue: 1,
                column: "InventoryId",
                value: 1);
        }
    }
}

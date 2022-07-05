using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class EditedShoppingCartsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "ShoppingCarts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ColourId",
                table: "ShoppingCarts",
                column: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Colours_ColourId",
                table: "ShoppingCarts",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Colours_ColourId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_ColourId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "ShoppingCarts");
        }
    }
}

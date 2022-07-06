using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class AddedColourToOrderItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "OrderItems",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "OrderItems");
        }
    }
}

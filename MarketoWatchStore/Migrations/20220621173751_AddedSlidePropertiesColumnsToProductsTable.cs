using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class AddedSlidePropertiesColumnsToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShareOnHomeSlide",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SlideImage",
                table: "Products",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShareOnHomeSlide",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SlideImage",
                table: "Products");
        }
    }
}

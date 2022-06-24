using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class UpdatedProductTabelAddedGendeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsForMen",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsForWomen",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsForMen",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsForWomen",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

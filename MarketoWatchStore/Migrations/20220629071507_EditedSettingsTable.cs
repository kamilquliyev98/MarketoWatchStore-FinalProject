using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class EditedSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "SupportPhone",
                table: "Settings",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupportText",
                table: "Settings",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportPhone",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SupportText",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "Settings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}

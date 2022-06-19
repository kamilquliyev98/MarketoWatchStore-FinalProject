using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class CreatedSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Logo = table.Column<string>(maxLength: 1000, nullable: true),
                    Offer = table.Column<string>(maxLength: 255, nullable: true),
                    Phone1 = table.Column<string>(maxLength: 255, nullable: false),
                    Phone2 = table.Column<string>(maxLength: 255, nullable: true),
                    Email1 = table.Column<string>(maxLength: 255, nullable: false),
                    Email2 = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    Facebook = table.Column<string>(maxLength: 1000, nullable: true),
                    Instagram = table.Column<string>(maxLength: 1000, nullable: true),
                    Twitter = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}

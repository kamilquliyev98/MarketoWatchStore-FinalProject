using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketoWatchStore.Migrations
{
    public partial class AddedRestoredAtColumnBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "SpecialTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "ServicePolicies",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "PowerSources",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Features",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Displays",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Colours",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestoredAt",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "SpecialTypes");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "ServicePolicies");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "PowerSources");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Displays");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Colours");

            migrationBuilder.DropColumn(
                name: "RestoredAt",
                table: "Brands");
        }
    }
}

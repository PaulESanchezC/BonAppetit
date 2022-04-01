using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class BugFixex_MenuMenuItem_MenuItemImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Menus_MenuBaseMenuId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuBaseMenuId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuBaseMenuId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 287, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 286, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 284, DateTimeKind.Local).AddTicks(3286));

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "MenuItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Menus_MenuId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 287, DateTimeKind.Local).AddTicks(272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 286, DateTimeKind.Local).AddTicks(4685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(9884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 284, DateTimeKind.Local).AddTicks(3286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "MenuBaseMenuId",
                table: "MenuItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(1211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuBaseMenuId",
                table: "MenuItems",
                column: "MenuBaseMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Menus_MenuBaseMenuId",
                table: "MenuItems",
                column: "MenuBaseMenuId",
                principalTable: "Menus",
                principalColumn: "MenuId");
        }
    }
}

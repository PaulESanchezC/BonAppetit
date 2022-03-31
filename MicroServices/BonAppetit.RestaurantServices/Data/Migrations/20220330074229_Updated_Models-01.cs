using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Updated_Models01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantCuisineTyoe",
                table: "Restaurants",
                newName: "RestaurantCuisineType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 613, DateTimeKind.Local).AddTicks(4077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 375, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 612, DateTimeKind.Local).AddTicks(5676),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 375, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(1724),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 373, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.AddColumn<string>(
                name: "MenuDescription",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "menu descriptions");

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "menu name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(6797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 373, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 608, DateTimeKind.Local).AddTicks(6409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 372, DateTimeKind.Local).AddTicks(6172));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuDescription",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "RestaurantCuisineType",
                table: "Restaurants",
                newName: "RestaurantCuisineTyoe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 375, DateTimeKind.Local).AddTicks(7220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 613, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 375, DateTimeKind.Local).AddTicks(1525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 612, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 373, DateTimeKind.Local).AddTicks(4374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 373, DateTimeKind.Local).AddTicks(7797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(6797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 372, DateTimeKind.Local).AddTicks(6172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 608, DateTimeKind.Local).AddTicks(6409));
        }
    }
}

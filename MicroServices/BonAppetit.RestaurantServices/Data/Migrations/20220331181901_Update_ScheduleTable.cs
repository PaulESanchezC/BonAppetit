using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Update_ScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(6279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 613, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 612, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(4621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(8525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(6797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 598, DateTimeKind.Local).AddTicks(5855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 608, DateTimeKind.Local).AddTicks(6409));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Schedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 613, DateTimeKind.Local).AddTicks(4077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 612, DateTimeKind.Local).AddTicks(5676),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(1724),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 610, DateTimeKind.Local).AddTicks(6797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 30, 3, 42, 29, 608, DateTimeKind.Local).AddTicks(6409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 598, DateTimeKind.Local).AddTicks(5855));
        }
    }
}

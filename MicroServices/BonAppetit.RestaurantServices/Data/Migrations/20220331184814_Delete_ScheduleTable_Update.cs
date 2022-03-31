using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Delete_ScheduleTable_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Schedules_ScheduleId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_ScheduleId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleId",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 962, DateTimeKind.Local).AddTicks(5805),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 960, DateTimeKind.Local).AddTicks(5561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 961, DateTimeKind.Local).AddTicks(1075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(8525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 959, DateTimeKind.Local).AddTicks(3345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 598, DateTimeKind.Local).AddTicks(5855));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScheduleId",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 962, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(4621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 960, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 599, DateTimeKind.Local).AddTicks(8525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 961, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 598, DateTimeKind.Local).AddTicks(5855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 959, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 31, 14, 19, 1, 603, DateTimeKind.Local).AddTicks(6279)),
                    Friday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FridayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    FridayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    Monday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MondayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    MondayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    RestaurantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SaturdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    SaturdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    Sunday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SundayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    SundayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    Thursday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ThursdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    ThursdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TuesdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    TuesdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    WednesdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    WednesdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ScheduleId",
                table: "Restaurants",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Schedules_ScheduleId",
                table: "Restaurants",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Update_ScheduleTable_ReCreatedWithNewDataTypeAndForeighKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 286, DateTimeKind.Local).AddTicks(4685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 962, DateTimeKind.Local).AddTicks(5805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(9884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 960, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 284, DateTimeKind.Local).AddTicks(3286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 961, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(1211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 959, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    Sunday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SundayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    SundayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    Monday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MondayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    MondayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TuesdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    TuesdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    WednesdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    WednesdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    Thursday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ThursdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    ThursdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    Friday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FridayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    FridayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    Saturday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SaturdayOpenTime = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    SaturdayCloseTime = table.Column<int>(type: "int", nullable: false, defaultValue: 22),
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 287, DateTimeKind.Local).AddTicks(272))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RestaurantId",
                table: "Schedules",
                column: "RestaurantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 962, DateTimeKind.Local).AddTicks(5805),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 286, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 960, DateTimeKind.Local).AddTicks(5561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 961, DateTimeKind.Local).AddTicks(1075),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 284, DateTimeKind.Local).AddTicks(3286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 31, 14, 48, 13, 959, DateTimeKind.Local).AddTicks(3345),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(1211));
        }
    }
}

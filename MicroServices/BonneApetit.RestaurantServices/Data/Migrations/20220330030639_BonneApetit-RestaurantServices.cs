using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class BonneApetitRestaurantServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 375, DateTimeKind.Local).AddTicks(7220))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "restaurant name"),
                    RestaurantPhone = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "phone number"),
                    RestaurantAddress = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "address"),
                    RestaurantWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "website"),
                    RestaurantCiy = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "city"),
                    RestaurantCuisineTyoe = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "cuisine type"),
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 375, DateTimeKind.Local).AddTicks(1525)),
                    ZonePopularity = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                    table.ForeignKey(
                        name: "FK_Restaurants_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    ImageIndex = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true, defaultValue: "image description"),
                    ImageBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 372, DateTimeKind.Local).AddTicks(6172)),
                    RestaurantBaseRestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Restaurants_RestaurantBaseRestaurantId",
                        column: x => x.RestaurantBaseRestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    Public = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 373, DateTimeKind.Local).AddTicks(4374))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    TableName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, defaultValue: "table name / table number"),
                    HoursOpenForReservation = table.Column<double>(type: "float", nullable: false, defaultValue: 10.0),
                    FrequencyOfReservation = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    AmountOfSeats = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_Tables_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "NEWID()"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "menu item name: "),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "menu item description"),
                    CuisineType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "cuisine type"),
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 29, 23, 6, 39, 373, DateTimeKind.Local).AddTicks(7797)),
                    Public = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MenuBaseMenuId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuBaseMenuId",
                        column: x => x.MenuBaseMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_RestaurantBaseRestaurantId",
                table: "Images",
                column: "RestaurantBaseRestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ImageId",
                table: "MenuItems",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuBaseMenuId",
                table: "MenuItems",
                column: "MenuBaseMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ScheduleId",
                table: "Restaurants",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}

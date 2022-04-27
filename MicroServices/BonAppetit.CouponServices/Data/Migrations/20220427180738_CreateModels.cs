using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class CreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouponTypes",
                columns: table => new
                {
                    CouponTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponTypes", x => x.CouponTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCoupons",
                columns: table => new
                {
                    RestaurantCouponsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCoupons", x => x.RestaurantCouponsId);
                    table.ForeignKey(
                        name: "FK_RestaurantCoupons_CouponTypes_CouponTypeId",
                        column: x => x.CouponTypeId,
                        principalTable: "CouponTypes",
                        principalColumn: "CouponTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCoupons_CouponTypeId",
                table: "RestaurantCoupons",
                column: "CouponTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantCoupons");

            migrationBuilder.DropTable(
                name: "CouponTypes");
        }
    }
}

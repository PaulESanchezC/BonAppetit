using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableSeats = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationFor = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}

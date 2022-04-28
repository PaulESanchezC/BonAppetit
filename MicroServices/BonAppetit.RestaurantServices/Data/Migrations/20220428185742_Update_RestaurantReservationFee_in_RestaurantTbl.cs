using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Update_RestaurantReservationFee_in_RestaurantTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationFee",
                table: "Restaurants",
                newName: "RestaurantReservationFee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantReservationFee",
                table: "Restaurants",
                newName: "ReservationFee");
        }
    }
}

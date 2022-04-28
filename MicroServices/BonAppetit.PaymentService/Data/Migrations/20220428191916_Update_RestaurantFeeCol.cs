using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Update_RestaurantFeeCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantFee",
                table: "Payments",
                newName: "RestaurantReservationFee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantReservationFee",
                table: "Payments",
                newName: "RestaurantFee");
        }
    }
}

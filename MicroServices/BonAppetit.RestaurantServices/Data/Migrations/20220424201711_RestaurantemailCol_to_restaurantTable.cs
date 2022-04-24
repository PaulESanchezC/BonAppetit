using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RestaurantemailCol_to_restaurantTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantEmail",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantEmail",
                table: "Restaurants");
        }
    }
}

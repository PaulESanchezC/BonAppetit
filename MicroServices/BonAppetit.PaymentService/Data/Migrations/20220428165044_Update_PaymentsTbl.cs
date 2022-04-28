using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Update_PaymentsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayed",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TableSeats",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "RestaurantName",
                table: "Payments",
                newName: "SessionId");

            migrationBuilder.AddColumn<double>(
                name: "BonAppetitFee",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FederalTaxes",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProvincialTaxes",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RestaurantFee",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonAppetitFee",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FederalTaxes",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ProvincialTaxes",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RestaurantFee",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Payments",
                newName: "RestaurantName");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayed",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TableSeats",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

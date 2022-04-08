using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Delete_HoursOpenForReservationCol_from_TablesTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursOpenForReservation",
                table: "Tables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HoursOpenForReservation",
                table: "Tables",
                type: "float",
                nullable: false,
                defaultValue: 10.0);
        }
    }
}

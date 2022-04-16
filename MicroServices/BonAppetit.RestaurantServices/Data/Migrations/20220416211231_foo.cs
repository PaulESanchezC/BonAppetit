using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class foo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FrequencyOfReservation",
                table: "Tables",
                type: "float",
                nullable: false,
                defaultValue: 2.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AlterColumn<double>(
                name: "WednesdayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "WednesdayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);

            migrationBuilder.AlterColumn<double>(
                name: "TuesdayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "TuesdayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);

            migrationBuilder.AlterColumn<double>(
                name: "ThursdayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "ThursdayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);

            migrationBuilder.AlterColumn<double>(
                name: "SundayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "SundayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);

            migrationBuilder.AlterColumn<double>(
                name: "SaturdayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "SaturdayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);

            migrationBuilder.AlterColumn<double>(
                name: "MondayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "MondayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);

            migrationBuilder.AlterColumn<double>(
                name: "FridayOpenTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 12.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 12);

            migrationBuilder.AlterColumn<double>(
                name: "FridayCloseTime",
                table: "Schedules",
                type: "float",
                nullable: false,
                defaultValue: 22.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 22);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FrequencyOfReservation",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 2.0);

            migrationBuilder.AlterColumn<int>(
                name: "WednesdayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "WednesdayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);

            migrationBuilder.AlterColumn<int>(
                name: "TuesdayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "TuesdayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);

            migrationBuilder.AlterColumn<int>(
                name: "ThursdayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "ThursdayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);

            migrationBuilder.AlterColumn<int>(
                name: "SundayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "SundayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);

            migrationBuilder.AlterColumn<int>(
                name: "SaturdayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "SaturdayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);

            migrationBuilder.AlterColumn<int>(
                name: "MondayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "MondayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);

            migrationBuilder.AlterColumn<int>(
                name: "FridayOpenTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 12,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 12.0);

            migrationBuilder.AlterColumn<int>(
                name: "FridayCloseTime",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 22,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 22.0);
        }
    }
}

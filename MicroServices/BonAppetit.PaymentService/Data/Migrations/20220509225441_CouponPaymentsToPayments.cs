using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class CouponPaymentsToPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouponPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<int>(type: "int", nullable: false),
                    PaymentBasePaymentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponPayments_Payments_PaymentBasePaymentId",
                        column: x => x.PaymentBasePaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponPayments_PaymentBasePaymentId",
                table: "CouponPayments",
                column: "PaymentBasePaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponPayments");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Holidayaro.Data.Migrations
{
    public partial class InitialCreate16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaypalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardExpirationMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardExpirationYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardCvv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReservationId",
                table: "Payment",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddPharmacistPropertyToOrderAndPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_PharmacistId",
                table: "Orders",
                column: "PharmacistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_PharmacistId",
                table: "Orders",
                column: "PharmacistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_PharmacistId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Users_PharmacistId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PharmacistId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PharmacistId",
                table: "Orders");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddSalesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SaleId",
                table: "Prescriptions",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PharmacistId = table.Column<Guid>(nullable: false),
                    DateOfIssue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Users_PharmacistId",
                        column: x => x.PharmacistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleElements",
                columns: table => new
                {
                    SaleId = table.Column<Guid>(nullable: false),
                    MedicamentId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleElements", x => new { x.MedicamentId, x.SaleId });
                    table.ForeignKey(
                        name: "FK_SaleElements_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleElements_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_SaleId",
                table: "Prescriptions",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleElements_SaleId",
                table: "SaleElements",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PharmacistId",
                table: "Sales",
                column: "PharmacistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Sales_SaleId",
                table: "Prescriptions",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Sales_SaleId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "SaleElements");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_SaleId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Prescriptions");
        }
    }
}

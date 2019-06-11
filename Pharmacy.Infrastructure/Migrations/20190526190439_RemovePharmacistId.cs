using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class RemovePharmacistId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Users_PharmacistId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PharmacistId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PharmacistId",
                table: "Prescriptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PharmacistId",
                table: "Prescriptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PharmacistId",
                table: "Prescriptions",
                column: "PharmacistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Users_PharmacistId",
                table: "Prescriptions",
                column: "PharmacistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

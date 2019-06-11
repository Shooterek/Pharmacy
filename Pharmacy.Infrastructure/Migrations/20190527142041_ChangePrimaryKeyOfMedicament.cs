using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class ChangePrimaryKeyOfMedicament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderElements_Medicaments_MedicamentId",
                table: "OrderElements");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionElements_Medicaments_MedicamentId",
                table: "PrescriptionElements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleElements_Medicaments_MedicamentId",
                table: "SaleElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleElements",
                table: "SaleElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionElements",
                table: "PrescriptionElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderElements",
                table: "OrderElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicaments",
                table: "Medicaments");

            migrationBuilder.DropColumn(
                name: "MedicamentId",
                table: "SaleElements");

            migrationBuilder.DropColumn(
                name: "MedicamentId",
                table: "PrescriptionElements");

            migrationBuilder.DropColumn(
                name: "MedicamentId",
                table: "OrderElements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Medicaments");

            migrationBuilder.AddColumn<string>(
                name: "EanCode",
                table: "SaleElements",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EanCode",
                table: "PrescriptionElements",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EanCode",
                table: "OrderElements",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EanCode",
                table: "Medicaments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleElements",
                table: "SaleElements",
                columns: new[] { "EanCode", "SaleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionElements",
                table: "PrescriptionElements",
                columns: new[] { "EanCode", "PrescriptionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderElements",
                table: "OrderElements",
                columns: new[] { "EanCode", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicaments",
                table: "Medicaments",
                column: "EanCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderElements_Medicaments_EanCode",
                table: "OrderElements",
                column: "EanCode",
                principalTable: "Medicaments",
                principalColumn: "EanCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionElements_Medicaments_EanCode",
                table: "PrescriptionElements",
                column: "EanCode",
                principalTable: "Medicaments",
                principalColumn: "EanCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleElements_Medicaments_EanCode",
                table: "SaleElements",
                column: "EanCode",
                principalTable: "Medicaments",
                principalColumn: "EanCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderElements_Medicaments_EanCode",
                table: "OrderElements");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionElements_Medicaments_EanCode",
                table: "PrescriptionElements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleElements_Medicaments_EanCode",
                table: "SaleElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleElements",
                table: "SaleElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionElements",
                table: "PrescriptionElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderElements",
                table: "OrderElements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicaments",
                table: "Medicaments");

            migrationBuilder.DropColumn(
                name: "EanCode",
                table: "SaleElements");

            migrationBuilder.DropColumn(
                name: "EanCode",
                table: "PrescriptionElements");

            migrationBuilder.DropColumn(
                name: "EanCode",
                table: "OrderElements");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicamentId",
                table: "SaleElements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicamentId",
                table: "PrescriptionElements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicamentId",
                table: "OrderElements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "EanCode",
                table: "Medicaments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Medicaments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleElements",
                table: "SaleElements",
                columns: new[] { "MedicamentId", "SaleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionElements",
                table: "PrescriptionElements",
                columns: new[] { "MedicamentId", "PrescriptionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderElements",
                table: "OrderElements",
                columns: new[] { "MedicamentId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicaments",
                table: "Medicaments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderElements_Medicaments_MedicamentId",
                table: "OrderElements",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionElements_Medicaments_MedicamentId",
                table: "PrescriptionElements",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleElements_Medicaments_MedicamentId",
                table: "SaleElements",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

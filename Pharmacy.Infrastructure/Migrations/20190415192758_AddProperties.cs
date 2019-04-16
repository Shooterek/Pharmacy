using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeselNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressOfThePatient",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfFinalization",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumberOfTheDoctor",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfTheDoctor",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfThePatient",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NipOrRegonOfTheProvider",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeselNumberOfThePatient",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecializationOfTheDoctor",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurnameOfTheDoctor",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurnameOfThePatient",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "PrescriptionElements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentageOfRefund",
                table: "Medicaments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PeselNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressOfThePatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DateOfFinalization",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "LicenseNumberOfTheDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "NameOfTheDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "NameOfThePatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "NipOrRegonOfTheProvider",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PeselNumberOfThePatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SpecializationOfTheDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SurnameOfTheDoctor",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SurnameOfThePatient",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "PrescriptionElements");

            migrationBuilder.DropColumn(
                name: "PercentageOfRefund",
                table: "Medicaments");
        }
    }
}

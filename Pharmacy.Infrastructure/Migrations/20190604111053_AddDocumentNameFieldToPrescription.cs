using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddDocumentNameFieldToPrescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Prescriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Prescriptions");
        }
    }
}

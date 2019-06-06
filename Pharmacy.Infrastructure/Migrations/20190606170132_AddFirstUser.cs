using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Infrastructure.Migrations
{
    public partial class AddFirstUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Education", "Email", "FullName", "IsActive", "Password", "Role", "Salt", "UpdatedAt", "Username" },
                values: new object[] { new Guid("681eab59-b691-4473-8e1f-89b15e869595"), new DateTime(2019, 6, 6, 17, 1, 31, 905, DateTimeKind.Utc), "Lekarz psychiatra", "zdzislaw.grzybowski@gmail.com", "Zdzisław Grzybowski", true, "QGKV1MlHvDF8wLwq420gaGOUaIbr7xMcmDljIKyIdf9Piaa4XRzWVA==", "Admin", "4FcMvFItucMRCKri01i9zks2bFEHqek4iCii64u/atgZgvuBk2N8JQ==", new DateTime(2019, 6, 6, 17, 1, 31, 905, DateTimeKind.Utc), "zdzislaw.grzybowski@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("681eab59-b691-4473-8e1f-89b15e869595"));
        }
    }
}

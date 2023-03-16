using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessClub3.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a53f0179-0c73-43df-a2ee-f4aaff1b6069", 0, 0, "ae3f4f8f-04ba-4110-b6bf-5ec34a017b9a", null, false, null, false, null, null, "Ivo", null, "ADMIN", "AQAAAAEAACcQAAAAEOlwRdNsm4+yJB4Bems7N+JQy80C5Ad/f3ejOMqEjWPH6OGPF4cmlb9RKJw2W4eOow==", null, false, null, "Админ", "395de0dd-24d1-4b69-a1da-2e60fb2a18b2", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a53f0179-0c73-43df-a2ee-f4aaff1b6069");
        }
    }
}

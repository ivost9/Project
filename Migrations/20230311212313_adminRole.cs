using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessClub3.Migrations
{
    public partial class adminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d134180-3598-4660-8d19-e261b2d4d2db", "a53f0179-0c73-43df-a2ee-f4aaff1b6069" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a53f0179-0c73-43df-a2ee-f4aaff1b6069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bb46b5c-6b8c-4b87-bf57-9d46def19762", "AQAAAAEAACcQAAAAECKFd46xlTwll73l9f5ZR3fmMVnUU9bVmny86ge0Xgl/UgAAeeP+tsEgG/bENNxIOg==", "17ab626f-f469-4d53-9570-5b5e38294834" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d134180-3598-4660-8d19-e261b2d4d2db", "a53f0179-0c73-43df-a2ee-f4aaff1b6069" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a53f0179-0c73-43df-a2ee-f4aaff1b6069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae3f4f8f-04ba-4110-b6bf-5ec34a017b9a", "AQAAAAEAACcQAAAAEOlwRdNsm4+yJB4Bems7N+JQy80C5Ad/f3ejOMqEjWPH6OGPF4cmlb9RKJw2W4eOow==", "395de0dd-24d1-4b69-a1da-2e60fb2a18b2" });
        }
    }
}

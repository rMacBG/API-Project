using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "91ca24c4-2f20-45a5-8584-961c140c6f79");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a7723422-1f89-47cf-bc1b-4ad9bc2acf59");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0013cbff-d2ff-40f8-92e2-219a6a776de2", "351e4127-7d4e-48ab-85fa-6b126cd85a47", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c41c295-e87f-492a-a338-08fdab9f2982", "9ed50e52-bc36-4195-85bf-8a0d2e3dbcc0", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "0013cbff-d2ff-40f8-92e2-219a6a776de2");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "0c41c295-e87f-492a-a338-08fdab9f2982");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91ca24c4-2f20-45a5-8584-961c140c6f79", "3c86fe1f-59c7-43b4-81d0-dfc79696b2df", "user", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7723422-1f89-47cf-bc1b-4ad9bc2acf59", "0c0c6348-2a73-4608-a4cb-8f074f723cdd", "admin", "ADMIN" });
        }
    }
}

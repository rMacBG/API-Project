using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    public partial class edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "30d3dfe2-0081-45ce-81e3-23e5d729ace4", "40f2c0d0-355f-4266-be7b-294ad54e0989", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9626651f-ead7-4be5-8ec8-3a24ff1f8f48", "430d4963-a4cf-4b46-96cd-f703f755e964", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "30d3dfe2-0081-45ce-81e3-23e5d729ace4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9626651f-ead7-4be5-8ec8-3a24ff1f8f48");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0013cbff-d2ff-40f8-92e2-219a6a776de2", "351e4127-7d4e-48ab-85fa-6b126cd85a47", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c41c295-e87f-492a-a338-08fdab9f2982", "9ed50e52-bc36-4195-85bf-8a0d2e3dbcc0", "user", "USER" });
        }
    }
}

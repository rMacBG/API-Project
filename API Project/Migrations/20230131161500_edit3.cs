using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    public partial class edit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "076d7691-69cf-4701-9ba1-90b9f415da17", "f99836b5-159f-4cb7-b593-1ff517fe35b6", "user", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20df3bf3-e5d6-45b5-b519-83b651156c35", "d92cd4b0-5247-4106-91e4-3f88d9cb73e9", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "076d7691-69cf-4701-9ba1-90b9f415da17");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "20df3bf3-e5d6-45b5-b519-83b651156c35");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30d3dfe2-0081-45ce-81e3-23e5d729ace4", "40f2c0d0-355f-4266-be7b-294ad54e0989", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9626651f-ead7-4be5-8ec8-3a24ff1f8f48", "430d4963-a4cf-4b46-96cd-f703f755e964", "user", "USER" });
        }
    }
}

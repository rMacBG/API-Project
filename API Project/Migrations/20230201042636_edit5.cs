using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    public partial class edit5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "27bcb2be-4657-498b-a6f2-768e57a6d882");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "83917d3a-788c-4b54-8f54-423cb4aff301");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a477fbfd-9d1a-4426-9293-7f237eff5731", "4c5e7549-2a2b-4714-b68b-8143d8b836a2", "user", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acb42ae3-413d-4379-8e09-45a188dc3015", "ce6bdc53-1003-4167-8245-f2ab07fbd385", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a477fbfd-9d1a-4426-9293-7f237eff5731");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "acb42ae3-413d-4379-8e09-45a188dc3015");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27bcb2be-4657-498b-a6f2-768e57a6d882", "9243bdce-6d19-4539-b5c4-cf819135f704", "user", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83917d3a-788c-4b54-8f54-423cb4aff301", "127ccafd-860f-4c9d-a172-932a4b5e4480", "admin", "ADMIN" });
        }
    }
}

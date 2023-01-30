using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d908737-f69a-42e9-ad2a-768bd9c99d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d38fb17e-5f89-4686-8278-1d6f2594fed0");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "FullName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d095123-0786-4773-a57c-dae6c97811aa", "dc4ec951-50ae-46e7-a332-ba7bc5b4b671", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c81b1803-bdc5-42af-aeac-3e23d14fbdc1", "7907690f-b7e7-411f-a89f-1943260ca794", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d095123-0786-4773-a57c-dae6c97811aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c81b1803-bdc5-42af-aeac-3e23d14fbdc1");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d908737-f69a-42e9-ad2a-768bd9c99d0a", "02faed67-d859-4583-b496-999df16c3cd6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d38fb17e-5f89-4686-8278-1d6f2594fed0", "7973e904-f809-4067-9223-78fdbf4219c8", "user", "USER" });
        }
    }
}

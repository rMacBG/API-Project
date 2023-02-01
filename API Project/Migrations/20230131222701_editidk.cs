using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project.Migrations
{
    public partial class editidk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_BookId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "076d7691-69cf-4701-9ba1-90b9f415da17");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "20df3bf3-e5d6-45b5-b519-83b651156c35");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Categories",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_BookId",
                table: "Categories",
                newName: "IX_Categories_MyPropertyId");

            migrationBuilder.AddColumn<string>(
                name: "CategoryNames",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "bookId",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27bcb2be-4657-498b-a6f2-768e57a6d882", "9243bdce-6d19-4539-b5c4-cf819135f704", "user", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83917d3a-788c-4b54-8f54-423cb4aff301", "127ccafd-860f-4c9d-a172-932a4b5e4480", "admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_bookId",
                table: "Authors",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_bookId",
                table: "Authors",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Books_MyPropertyId",
                table: "Categories",
                column: "MyPropertyId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_bookId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_MyPropertyId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Authors_bookId",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "27bcb2be-4657-498b-a6f2-768e57a6d882");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "83917d3a-788c-4b54-8f54-423cb4aff301");

            migrationBuilder.DropColumn(
                name: "CategoryNames",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "bookId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "Categories",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_MyPropertyId",
                table: "Categories",
                newName: "IX_Categories_BookId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "076d7691-69cf-4701-9ba1-90b9f415da17", "f99836b5-159f-4cb7-b593-1ff517fe35b6", "user", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20df3bf3-e5d6-45b5-b519-83b651156c35", "d92cd4b0-5247-4106-91e4-3f88d9cb73e9", "admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Books_BookId",
                table: "Categories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

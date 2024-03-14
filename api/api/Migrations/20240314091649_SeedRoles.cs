using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f20a6e1-2fd3-4ba6-92c2-2e02df07f052");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73cda707-4dc8-4796-888c-bf1448dadb63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "907327b8-6c98-47ae-b7d7-afbdcc64adcc", null, "User", "USER" },
                    { "9e951527-e111-4792-b5f9-d3a3f953ccbd", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "907327b8-6c98-47ae-b7d7-afbdcc64adcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e951527-e111-4792-b5f9-d3a3f953ccbd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f20a6e1-2fd3-4ba6-92c2-2e02df07f052", null, "User", "USER" },
                    { "73cda707-4dc8-4796-888c-bf1448dadb63", null, "Admin", "ADMIN" }
                });
        }
    }
}

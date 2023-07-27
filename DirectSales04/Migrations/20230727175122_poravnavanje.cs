using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectSales04.Migrations
{
    public partial class poravnavanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1",
                column: "ConcurrencyStamp",
                value: "b21e0013-a24e-4812-bb9f-aa6c2b252dfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20",
                column: "ConcurrencyStamp",
                value: "2a27d1cf-044b-491e-a6d0-0fc896c3c3ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "858b09cd-733e-4ea5-8cdf-f3dc4fcd8533", "AQAAAAEAACcQAAAAED+4Kg9OZecCbJIMxINhXC/YpdLOqFt36SmizhXudAFyIO8+H5m0mAVHzNAhldj02Q==", "489b6d8b-7a5d-4f2c-9492-248cc2c252a5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1",
                column: "ConcurrencyStamp",
                value: "ddea2ede-29d5-47cf-9118-1c6e718dab47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20",
                column: "ConcurrencyStamp",
                value: "c6c872a7-f189-4ba8-90f0-f9b68801d20f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5d690d4-ca4b-46bc-8715-0db499369922", "AQAAAAEAACcQAAAAEJ7Fi7mCl1cANx4ltYTgA+6ZeeQBHIGc77Ra4djvUGIouGUxyM2f830olm9ZlxhEXA==", "78e95659-72c9-41e8-b36b-349c851c58db" });
        }
    }
}

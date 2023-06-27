using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectSales04.Migrations
{
    public partial class AppContextRew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e71d461-63e3-4aa5-be93-d701a5a1f913");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6217999e-a9fb-448b-b163-e2305fc44f50", "66412151-dd0c-4b69-82c8-0f4256e78f00" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6217999e-a9fb-448b-b163-e2305fc44f50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66412151-dd0c-4b69-82c8-0f4256e78f00");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41112308 - 4603 - 420b - be22 - 3af8a2166be1", "4d643cc9-c350-4ab9-b148-03bd491e4c02", "Customers", "CUSTOMERS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20", "ad3cccd8-8f19-4e8f-9f4c-fb9db709edb0", "Admins", "ADMINS" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588", 0, "Donji Glib 56", "d5111f80-d2c5-4d16-884a-d6a89a433255", "admin@direct-sales.com", false, "Tvrtko", "Tvrdic", false, null, "ADMIN@DIRECT-SALES.COM", "ADMIN@DIRECT-SALES.COM", "AQAAAAEAACcQAAAAEPeRsF4ERzZ0T3y5D5wxHbjTKzK6iFnQILvr0I10jJc/Xqrp0lLXK6MKegGNjNDVHw==", null, false, "03c1a067-fac8-40fd-8c3e-85dcc3d0cbec", false, "admin@direct-sales.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20", "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20", "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e71d461-63e3-4aa5-be93-d701a5a1f913", "0f0829c4-75b1-4dfa-94f4-11c5d8a30a53", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6217999e-a9fb-448b-b163-e2305fc44f50", "d2d7112e-3cca-4fc6-a74e-c1cebecc7bd3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66412151-dd0c-4b69-82c8-0f4256e78f00", 0, "Stara Cesta bb", "b9782f89-ce5f-42dd-9621-fa399b01e93b", "mico@admin.com", false, "Mićo", "Programerić", false, null, "MICO@ADMIN.COM", "MICO@ADMIN.COM", "AQAAAAEAACcQAAAAEMwNij5WVqsGPLHroJetYnUUWD/5/WbfkIJTj7Vuyngbw/pchCIKXAq6U4fIS0ohtQ==", null, false, "1fad8052-6a94-4e49-b130-59f7d7c9ad14", false, "mico@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6217999e-a9fb-448b-b163-e2305fc44f50", "66412151-dd0c-4b69-82c8-0f4256e78f00" });
        }
    }
}

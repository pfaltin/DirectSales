using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectSales04.Migrations
{
    public partial class AddedSaleSaleiemEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "SalesId", "ClientId", "Date", "Remarks" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "prva prodaja " },
                    { 2, 1, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "druga prodaja " },
                    { 3, 2, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "treca prodaja " },
                    { 4, 3, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "cetvrta prodaja " },
                    { 5, 4, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "peta prodaja " }
                });

            migrationBuilder.InsertData(
                table: "SaleItem",
                columns: new[] { "SaleItemID", "Discount", "Price", "ProductId", "Quantity", "SaleId", "Status", "SubTotal" },
                values: new object[,]
                {
                    { 1, 0, 0m, 5, 2, 1, 0, 12.22m },
                    { 2, 0, 0m, 11, 1, 1, 0, 22.22m },
                    { 3, 0, 0m, 12, 2, 2, 1, 32.22m },
                    { 4, 0, 0m, 6, 3, 2, 1, 2.22m },
                    { 5, 0, 0m, 3, 5, 2, 1, 3.22m },
                    { 6, 0, 0m, 4, 7, 3, 4, 4.22m },
                    { 7, 0, 0m, 8, 8, 3, 4, 5.22m },
                    { 8, 0, 0m, 19, 9, 3, 5, 7.22m },
                    { 9, 0, 0m, 21, 2, 4, 2, 12.22m },
                    { 10, 0, 0m, 15, 3, 4, 2, 22.22m },
                    { 11, 0, 0m, 16, 4, 5, 1, 23.22m },
                    { 12, 0, 0m, 17, 2, 5, 1, 26.22m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SaleItem",
                keyColumn: "SaleItemID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "SalesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "SalesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "SalesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "SalesId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "SalesId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1",
                column: "ConcurrencyStamp",
                value: "3e80c141-7f28-447f-9a4b-517f7df4c9aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20",
                column: "ConcurrencyStamp",
                value: "ea8e8b3f-cf4b-46dc-92f3-0b50a76b73c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4b9f82a-ea34-4fdf-8861-2441d163e274", "AQAAAAEAACcQAAAAEJzwFqdlTW46wZFFqUdOb7ExRmAJBYKRxRi8m4gPYUtLMUfkhIZIO1PFJkWGRUFeUw==", "e3913f48-ddee-459f-b205-316880eca669" });
        }
    }
}

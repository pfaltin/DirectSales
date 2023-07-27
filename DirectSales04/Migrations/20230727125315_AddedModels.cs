using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectSales04.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    SKU = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1",
                column: "ConcurrencyStamp",
                value: "dfc30499-66ac-48e8-a0dc-387b6f897d1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20",
                column: "ConcurrencyStamp",
                value: "ab2ab651-a4af-4ba8-8723-641a20534abd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f996ab6f-204d-458f-af2a-60e99b1562a9", "AQAAAAEAACcQAAAAEPL+0MCJ0Y42DOpPcKDcrBZUOEW6EQPp4rmXIEH1juLHjdeIKf+fpGCfZ7xnMCXhzA==", "bf9a4658-a907-4fce-b4a1-ebd0d0f4be3c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1",
                column: "ConcurrencyStamp",
                value: "4d643cc9-c350-4ab9-b148-03bd491e4c02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20",
                column: "ConcurrencyStamp",
                value: "ad3cccd8-8f19-4e8f-9f4c-fb9db709edb0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5111f80-d2c5-4d16-884a-d6a89a433255", "AQAAAAEAACcQAAAAEPeRsF4ERzZ0T3y5D5wxHbjTKzK6iFnQILvr0I10jJc/Xqrp0lLXK6MKegGNjNDVHw==", "03c1a067-fac8-40fd-8c3e-85dcc3d0cbec" });
        }
    }
}

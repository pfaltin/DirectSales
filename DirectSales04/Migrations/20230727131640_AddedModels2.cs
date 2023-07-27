using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectSales04.Migrations
{
    public partial class AddedModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    OIB = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Remarks = table.Column<string>(type: "ntext", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategorie",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategorie", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategorie_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategorie_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41112308 - 4603 - 420b - be22 - 3af8a2166be1",
                column: "ConcurrencyStamp",
                value: "27773cba-6b71-4797-bc3f-5c355af744bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20",
                column: "ConcurrencyStamp",
                value: "b325b4e0-fba7-40e6-bc18-20cc58695951");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "702d4524-021c-459f-9388-2f4e2a4a9261", "AQAAAAEAACcQAAAAELLPoen5PX3ZhkWxRVQcGTynmBBeUYOV2HbVuE799rVy1CmRV39zrYi3bOyxTcGbsg==", "f29d05b3-4f11-45a0-aa43-b04540f4d0fe" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Ulje", "Ulja" },
                    { 2, "Esencija", "Esencije" },
                    { 3, "Kupka", "Za kupanje" },
                    { 4, "Krema", "Za mazanje" },
                    { 5, "Ostalo", "Razno" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "City", "Country", "Email", "OIB", "Phone", "PostalCode", "Remarks", "Street", "Title" },
                values: new object[,]
                {
                    { 1, "Zagoroza", "Stripland", "zagor@zagor.tw", "41234", "5647456", "3412", "z", "Gornja 3", "Zagor" },
                    { 2, "Blektown", "Stripland", "blek@blek.bl", "452345", "4523523", "1234", "s", "Donja 7", "Blek" },
                    { 3, "Brdar", "Stripland", "mirko@mirko.mi", "6785678", "78907890", "4536", "h", "Lijeva 34", "Mirko" },
                    { 4, "Mrkvine", "Stripland", "slavko@slavko.sl", "567856", "45674567", "1234", "g", "Desna", "Slavko" },
                    { 5, "Konjski", "Stripland", "miki@miki.mi", "56785678", "3456345", "7687", "d", "Laka 978", "Miki" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "Image", "Price", "SKU", "Title" },
                values: new object[,]
                {
                    { 1, "Umirujuce i procišcavajuce djelovanje, za cijelu obitelj. 10 ml", "3816.png", 26.22m, 0, "ULJE TEA TREE" },
                    { 2, "Mir i vedrina sugestivnog mirisa. 10 ml", "3804.png", 97.34m, 0, "ULJE LAVANDE" },
                    { 3, "Procišcavajuca svojstva i energizirajuci miris. 10 ml", "3801.png", 4.34m, 0, "ULJE LIMUNA" },
                    { 4, "Suncana atmosfera za dobro raspoloženje. 10 ml", "3806.png", 7.34m, 0, "ULJE NARANČE" },
                    { 5, "Za obnovljeni osjecaj svježine i koncentracije. 10 ml", "3850.png", 45.34m, 0, "ULJE METVICE" },
                    { 6, "Slatke note agruma za pospješivanje tonusa, na harmonican nacin. 10 ml", "3997.png", 32.34m, 0, "ENERGY+ " },
                    { 7, "Nešto što uvijek mora biti nadohvat ruke, za blagostanje i ravnotežu. 10 ml", "3995.png", 6.34m, 0, "ANTISTRES " },
                    { 8, "Balzamicna mješavina s djelotvornim ucinkom procišcavanja.10 ml", "3802.png", 9.4m, 0, "EUKALIPTUS" },
                    { 9, "Originalna mješavina s 31 biljkom. 75 ml", "3515.png", 22.14m, 0, "ULJE 31" },
                    { 10, "Dragocjena mješavina soli, za procišcenu i glatku kožu. Sa solima iz Mrtvog mora, crnim sljezom, borovicom.500 g", "3490.png", 2.34m, 0, "SOL ZA KUPANJE SAN’ACTIV" },
                    { 11, "Nježan i mazan, za osjetljivu kožu. S medom, rižom, mlijekom, i zobi. 250 ml", "3459.png", 22.34m, 0, "GEL ZA TUŠIRANJE MED, RIŽA, MLIJEKO, ZOB" },
                    { 12, "Nježan eksfolijantni piling za tijelo, s detoksicirajucim i uravnotežujucim djelovanjem, kako bi koži tijela vratio sjaj i vitalnost. Sa solima iz Mrtvog mora, spirulinom. 150 ml", "3494.png", 12.34m, 0, "DETOKS PILING ZA TIJELO" },
                    { 13, "Topli predah s opuštajucim ucinkom.S borovicom, vražjom kandžom, arnikom. 75 ml", "3443.png", 33.34m, 0, "ESENCIJA BOROVICE" },
                    { 14, "Mirisna atmosfera za ravnotežu i sklad.Sa sandalovinom, ylang ylangom,jasminom. 75 ml", "3460.png", 65.34m, 0, "ESENCIJA SANDALOVINE" },
                    { 15, "Kada je potrebno više energije i izdržljivosti. S ehinacejom, sibirskim ginsengom, cumbirom. 75 ml", "3409.png", 32.34m, 0, "ESENCIJA EHINACEJE" },
                    { 16, "Više mira i opuštanja, za obnovljenu ravnotežu. S maticnjakom, kamilicom, lavandom.75 ml", "3452.png", 98.34m, 0, "ESENCIJA MATIČNJAKA" },
                    { 17, "Okrepljujuci ucinak i intenzivna balzamicna svojstva. S majcinom dušicom, eukaliptusom, kaduljom. 75 ml", "3410.png", 42.34m, 0, "ESENCIJA MAJČINE DUŠICE" },
                    { 18, "Za cistu, tonicnu i meku kožu. S morskim algama, zelenim cajem.250 ml", "3380.png", 82.8m, 0, "MORSKA KUPKA" },
                    { 19, "Za stimulirajuci i osnažujuci osjecaj na koži. Sa cvjetovima sijena, arnikom, runolistom. 250 ml", "3381.png", 21.34m, 0, "ALPSKA KUPKA" },
                    { 20, "Dubinsko opuštanje,idealno prije spavanja.S valerijanom, bijelim glogom. 250 ml", "3382.png", 34.34m, 0, "RELAKSIRAJUcA KUPKA" },
                    { 21, "Nova ravnoteža zahvaljujuci biljkama s harmonizirajucim ucinkom. S gospinom travom, bergamotom. 250 ml", "3383.png", 52.34m, 0, "HARMONIZIRAJUĆA KUPKA" },
                    { 22, "Za pospješivanje pravilne ravnoteže kože podložne promjenama i tegobama. S cajevcem, manukom i rosalinom. 100 ml", "3511.png", 62.34m, 0, "TEA TREE KREMA" },
                    { 23, "Zaštitno i emolijantno djelovanje za kožu izloženu vanjskim cimbenicima. S nevenom, crnim sljezom, ehinacejom. 100 ml", "3514.png", 72.34m, 0, "KREMA OD NEVENA" },
                    { 24, "Majcina dušica za balzamicno i stimulirajuce djelovanje. S majcinom dušicom, eukaliptusom, ružmarinom. 100 ml", "3518.png", 82.34m, 0, "KREMA OD MAJČINE DUŠICE" },
                    { 25, "Calendula officinalis. Blagotvorni stimulirajuci i zagrijavajuci osjecaj na koži. S borovicom, borom, cempresom. 100 ml", "3517.png", 92.34m, 0, "KREMA OD BOROVICE" },
                    { 26, "Trenutno olakšanje za kožu na mjestima ozljede ili išcašenja. S gavezom, arnikom. 100 ml", "3547.png", 12.34m, 0, "KREMASTI GEL GAVEZ" },
                    { 27, "Ugodan osjecaj svježe suhoce za kožu tijela. S arnikom, kaduljom, maticnjakom. 100 ml", "3774.png", 134.54m, 0, "GEL BODYFRESH" },
                    { 28, "Za masaže koje pružaju  olakšanje mišicima i zglobovima. Soli iz Mrtvog mora, vidac, pšenicne klice. 100 ml", "3512.png", 22.34m, 0, "KREMA SAN’ACTIV" },
                    { 29, "Umiruje i opušta, za osjetljivu kožu. S lavandom, aloe verom, hamamelisom. 100 ml", "3516.png", 121.34m, 0, "KREMA OD LAVANDE" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "Image", "Price", "SKU", "Title" },
                values: new object[] { 30, "Korisna zbog blagotvornog djelovanja na kožu, posebno na predjelima koje karakterizira napetost u zglobovima ili mišicima. S arnikom, vražjom kandžom, tamjanom. 100 ml", "3503.png", 16.67m, 0, "KREMASTI GEL ARNIKA I HARPAGOFIT" });

            migrationBuilder.InsertData(
                table: "ProductCategorie",
                columns: new[] { "ProductCategoryId", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 1, 7 },
                    { 8, 1, 8 },
                    { 9, 1, 9 },
                    { 10, 2, 10 },
                    { 11, 2, 11 },
                    { 12, 2, 12 },
                    { 13, 2, 13 },
                    { 14, 2, 14 },
                    { 15, 3, 15 },
                    { 16, 3, 16 },
                    { 17, 3, 17 },
                    { 18, 3, 18 },
                    { 19, 3, 19 },
                    { 20, 4, 20 },
                    { 21, 4, 21 },
                    { 22, 4, 22 },
                    { 23, 4, 23 },
                    { 24, 4, 24 },
                    { 25, 5, 25 },
                    { 26, 5, 26 },
                    { 27, 5, 27 },
                    { 28, 5, 28 },
                    { 29, 5, 29 },
                    { 30, 5, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorie_CategoryId",
                table: "ProductCategorie",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorie_ProductId",
                table: "ProductCategorie",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ProductCategorie");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 30);

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
    }
}

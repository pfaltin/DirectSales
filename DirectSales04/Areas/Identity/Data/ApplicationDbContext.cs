using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DirectSales04.Models;

namespace DirectSales04.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
           new Category { CategoryId = 1, Description = "Ulja", CategoryName = "Ulje" },
           new Category { CategoryId = 2, Description = "Esencije", CategoryName = "Esencija" },
           new Category { CategoryId = 3, Description = "Za kupanje", CategoryName = "Kupka" },
           new Category { CategoryId = 4, Description = "Za mazanje", CategoryName = "Krema" },
           new Category { CategoryId = 5, Description = "Razno", CategoryName = "Ostalo" });


            builder.Entity<Product>().HasData(
                        new Product { ProductId = 1, Title = "ULJE TEA TREE", Description = "Umirujuce i procišcavajuce djelovanje, za cijelu obitelj. 10 ml", Image = "3816.png", Price = 26.22M },
                        new Product { ProductId = 2, Title = "ULJE LAVANDE", Description = "Mir i vedrina sugestivnog mirisa. 10 ml", Image = "3804.png", Price = 97.34M },
                        new Product { ProductId = 3, Title = "ULJE LIMUNA", Description = "Procišcavajuca svojstva i energizirajuci miris. 10 ml", Image = "3801.png", Price = 4.34M },
                        new Product { ProductId = 4, Title = "ULJE NARANČE", Description = "Suncana atmosfera za dobro raspoloženje. 10 ml", Image = "3806.png", Price = 7.34M },
                        new Product { ProductId = 5, Title = "ULJE METVICE", Description = "Za obnovljeni osjecaj svježine i koncentracije. 10 ml", Image = "3850.png", Price = 45.34M },
                        new Product { ProductId = 6, Title = "ENERGY+ ", Description = "Slatke note agruma za pospješivanje tonusa, na harmonican nacin. 10 ml", Image = "3997.png", Price = 32.34M },
                        new Product { ProductId = 7, Title = "ANTISTRES ", Description = "Nešto što uvijek mora biti nadohvat ruke, za blagostanje i ravnotežu. 10 ml", Image = "3995.png", Price = 6.34M },
                        new Product { ProductId = 8, Title = "EUKALIPTUS", Description = "Balzamicna mješavina s djelotvornim ucinkom procišcavanja.10 ml", Image = "3802.png", Price = 9.4M },
                        new Product { ProductId = 9, Title = "ULJE 31", Description = "Originalna mješavina s 31 biljkom. 75 ml", Image = "3515.png", Price = 22.14M },
                        new Product { ProductId = 10, Title = "SOL ZA KUPANJE SAN’ACTIV", Description = "Dragocjena mješavina soli, za procišcenu i glatku kožu. Sa solima iz Mrtvog mora, crnim sljezom, borovicom.500 g", Image = "3490.png", Price = 2.34M },
                        new Product { ProductId = 11, Title = "GEL ZA TUŠIRANJE MED, RIŽA, MLIJEKO, ZOB", Description = "Nježan i mazan, za osjetljivu kožu. S medom, rižom, mlijekom, i zobi. 250 ml", Image = "3459.png", Price = 22.34M },
                        new Product { ProductId = 12, Title = "DETOKS PILING ZA TIJELO", Description = "Nježan eksfolijantni piling za tijelo, s detoksicirajucim i uravnotežujucim djelovanjem, kako bi koži tijela vratio sjaj i vitalnost. Sa solima iz Mrtvog mora, spirulinom. 150 ml", Image = "3494.png", Price = 12.34M },
                        new Product { ProductId = 13, Title = "ESENCIJA BOROVICE", Description = "Topli predah s opuštajucim ucinkom.S borovicom, vražjom kandžom, arnikom. 75 ml", Image = "3443.png", Price = 33.34M },
                        new Product { ProductId = 14, Title = "ESENCIJA SANDALOVINE", Description = "Mirisna atmosfera za ravnotežu i sklad.Sa sandalovinom, ylang ylangom,jasminom. 75 ml", Image = "3460.png", Price = 65.34M },
                        new Product { ProductId = 15, Title = "ESENCIJA EHINACEJE", Description = "Kada je potrebno više energije i izdržljivosti. S ehinacejom, sibirskim ginsengom, cumbirom. 75 ml", Image = "3409.png", Price = 32.34M },
                        new Product { ProductId = 16, Title = "ESENCIJA MATIČNJAKA", Description = "Više mira i opuštanja, za obnovljenu ravnotežu. S maticnjakom, kamilicom, lavandom.75 ml", Image = "3452.png", Price = 98.34M },
                        new Product { ProductId = 17, Title = "ESENCIJA MAJČINE DUŠICE", Description = "Okrepljujuci ucinak i intenzivna balzamicna svojstva. S majcinom dušicom, eukaliptusom, kaduljom. 75 ml", Image = "3410.png", Price = 42.34M },
                        new Product { ProductId = 18, Title = "MORSKA KUPKA", Description = "Za cistu, tonicnu i meku kožu. S morskim algama, zelenim cajem.250 ml", Image = "3380.png", Price = 82.8M },
                        new Product { ProductId = 19, Title = "ALPSKA KUPKA", Description = "Za stimulirajuci i osnažujuci osjecaj na koži. Sa cvjetovima sijena, arnikom, runolistom. 250 ml", Image = "3381.png", Price = 21.34M },
                        new Product { ProductId = 20, Title = "RELAKSIRAJUcA KUPKA", Description = "Dubinsko opuštanje,idealno prije spavanja.S valerijanom, bijelim glogom. 250 ml", Image = "3382.png", Price = 34.34M },
                        new Product { ProductId = 21, Title = "HARMONIZIRAJUĆA KUPKA", Description = "Nova ravnoteža zahvaljujuci biljkama s harmonizirajucim ucinkom. S gospinom travom, bergamotom. 250 ml", Image = "3383.png", Price = 52.34M },
                        new Product { ProductId = 22, Title = "TEA TREE KREMA", Description = "Za pospješivanje pravilne ravnoteže kože podložne promjenama i tegobama. S cajevcem, manukom i rosalinom. 100 ml", Image = "3511.png", Price = 62.34M },
                        new Product { ProductId = 23, Title = "KREMA OD NEVENA", Description = "Zaštitno i emolijantno djelovanje za kožu izloženu vanjskim cimbenicima. S nevenom, crnim sljezom, ehinacejom. 100 ml", Image = "3514.png", Price = 72.34M },
                        new Product { ProductId = 24, Title = "KREMA OD MAJČINE DUŠICE", Description = "Majcina dušica za balzamicno i stimulirajuce djelovanje. S majcinom dušicom, eukaliptusom, ružmarinom. 100 ml", Image = "3518.png", Price = 82.34M },
                        new Product { ProductId = 25, Title = "KREMA OD BOROVICE", Description = "Calendula officinalis. Blagotvorni stimulirajuci i zagrijavajuci osjecaj na koži. S borovicom, borom, cempresom. 100 ml", Image = "3517.png", Price = 92.34M },
                        new Product { ProductId = 26, Title = "KREMASTI GEL GAVEZ", Description = "Trenutno olakšanje za kožu na mjestima ozljede ili išcašenja. S gavezom, arnikom. 100 ml", Image = "3547.png", Price = 12.34M },
                        new Product { ProductId = 27, Title = "GEL BODYFRESH", Description = "Ugodan osjecaj svježe suhoce za kožu tijela. S arnikom, kaduljom, maticnjakom. 100 ml", Image = "3774.png", Price = 134.54M },
                        new Product { ProductId = 28, Title = "KREMA SAN’ACTIV", Description = "Za masaže koje pružaju  olakšanje mišicima i zglobovima. Soli iz Mrtvog mora, vidac, pšenicne klice. 100 ml", Image = "3512.png", Price = 22.34M },
                        new Product { ProductId = 29, Title = "KREMA OD LAVANDE", Description = "Umiruje i opušta, za osjetljivu kožu. S lavandom, aloe verom, hamamelisom. 100 ml", Image = "3516.png", Price = 121.34M },
                        new Product { ProductId = 30, Title = "KREMASTI GEL ARNIKA I HARPAGOFIT", Description = "Korisna zbog blagotvornog djelovanja na kožu, posebno na predjelima koje karakterizira napetost u zglobovima ili mišicima. S arnikom, vražjom kandžom, tamjanom. 100 ml", Image = "3503.png", Price = 16.67M });

            builder.Entity<ProductCategorie>().HasData(
                new ProductCategorie { ProductCategoryId = 1, CategoryId = 1, ProductId = 1 },
                new ProductCategorie { ProductCategoryId = 2, CategoryId = 1, ProductId = 2 },
                new ProductCategorie { ProductCategoryId = 3, CategoryId = 1, ProductId = 3 },
                new ProductCategorie { ProductCategoryId = 4, CategoryId = 1, ProductId = 4 },
                new ProductCategorie { ProductCategoryId = 5, CategoryId = 1, ProductId = 5 },
                new ProductCategorie { ProductCategoryId = 6, CategoryId = 1, ProductId = 6 },
                new ProductCategorie { ProductCategoryId = 7, CategoryId = 1, ProductId = 7 },
                new ProductCategorie { ProductCategoryId = 8, CategoryId = 1, ProductId = 8 },
                new ProductCategorie { ProductCategoryId = 9, CategoryId = 1, ProductId = 9 },
                new ProductCategorie { ProductCategoryId = 10, CategoryId = 2, ProductId = 10 },
                new ProductCategorie { ProductCategoryId = 11, CategoryId = 2, ProductId = 11 },
                new ProductCategorie { ProductCategoryId = 12, CategoryId = 2, ProductId = 12 },
                new ProductCategorie { ProductCategoryId = 13, CategoryId = 2, ProductId = 13 },
                new ProductCategorie { ProductCategoryId = 14, CategoryId = 2, ProductId = 14 },
                new ProductCategorie { ProductCategoryId = 15, CategoryId = 3, ProductId = 15 },
                new ProductCategorie { ProductCategoryId = 16, CategoryId = 3, ProductId = 16 },
                new ProductCategorie { ProductCategoryId = 17, CategoryId = 3, ProductId = 17 },
                new ProductCategorie { ProductCategoryId = 18, CategoryId = 3, ProductId = 18 },
                new ProductCategorie { ProductCategoryId = 19, CategoryId = 3, ProductId = 19 },
                new ProductCategorie { ProductCategoryId = 20, CategoryId = 4, ProductId = 20 },
                new ProductCategorie { ProductCategoryId = 21, CategoryId = 4, ProductId = 21 },
                new ProductCategorie { ProductCategoryId = 22, CategoryId = 4, ProductId = 22 },
                new ProductCategorie { ProductCategoryId = 23, CategoryId = 4, ProductId = 23 },
                new ProductCategorie { ProductCategoryId = 24, CategoryId = 4, ProductId = 24 },
                new ProductCategorie { ProductCategoryId = 25, CategoryId = 5, ProductId = 25 },
                new ProductCategorie { ProductCategoryId = 26, CategoryId = 5, ProductId = 26 },
                new ProductCategorie { ProductCategoryId = 27, CategoryId = 5, ProductId = 27 },
                new ProductCategorie { ProductCategoryId = 28, CategoryId = 5, ProductId = 28 },
                new ProductCategorie { ProductCategoryId = 29, CategoryId = 5, ProductId = 29 },
                new ProductCategorie { ProductCategoryId = 30, CategoryId = 5, ProductId = 30 }
                );

            builder.Entity<Client>().HasData(
                new Client { ClientId = 1, Title = "Zagor", OIB = "41234", Email = "zagor@zagor.tw", Phone = "5647456", Street = "Gornja 3", City = "Zagoroza", PostalCode = "3412", Country = "Stripland", Remarks = "z" },
                new Client { ClientId = 2, Title = "Blek", OIB = "452345", Email = "blek@blek.bl", Phone = "4523523", Street = "Donja 7", City = "Blektown", PostalCode = "1234", Country = "Stripland", Remarks = "s" },
                new Client { ClientId = 3, Title = "Mirko", OIB = "6785678", Email = "mirko@mirko.mi", Phone = "78907890", Street = "Lijeva 34", City = "Brdar", PostalCode = "4536", Country = "Stripland", Remarks = "h" },
                new Client { ClientId = 4, Title = "Slavko", OIB = "567856", Email = "slavko@slavko.sl", Phone = "45674567", Street = "Desna", City = "Mrkvine", PostalCode = "1234", Country = "Stripland", Remarks = "g" },
                new Client { ClientId = 5, Title = "Miki", OIB = "56785678", Email = "miki@miki.mi", Phone = "3456345", Street = "Laka 978", City = "Konjski", PostalCode = "7687", Country = "Stripland", Remarks = "d" }
                );






            string AdminRoleId = "5109cf15 - d38d - 4fe9 - b385 - 2972b2d2bb20";
            string AdminRoleTitle = "Admins";
            string UserRoleId = "41112308 - 4603 - 420b - be22 - 3af8a2166be1";
            string UserRoleTitle = "Customers";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = AdminRoleId, Name = AdminRoleTitle, NormalizedName = AdminRoleTitle.ToUpper() },
                new IdentityRole { Id = UserRoleId, Name = UserRoleTitle, NormalizedName = UserRoleTitle.ToUpper() });

            string adminUserId = "e4e48ebc - dde2 - 44ef - aa10 - f77c91acc588";
            string adminUser = "admin@direct-sales.com";
            string adminEmail = "admin@direct-sales.com";
            string adminFirstName = "Tvrtko";
            string adminLastName = "Tvrdic";
            string adminPwd = "L0zinka09";
            string adminAddr = "Donji Glib 56";

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = adminUserId, UserName = adminUser, FirstName = adminFirstName, LastName = adminLastName, Email = adminEmail, Address = adminAddr, PasswordHash = hasher.HashPassword(null, adminPwd), NormalizedUserName = adminUser.ToUpper(), NormalizedEmail = adminEmail.ToUpper() });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = adminUserId, RoleId = AdminRoleId });


        }

        public DbSet<DirectSales04.Models.Product>? Product { get; set; }

        public DbSet<DirectSales04.Models.ProductCategorie>? ProductCategorie { get; set; }

        public DbSet<DirectSales04.Models.Client>? Client { get; set; }

        public DbSet<DirectSales04.Models.Category>? Category { get; set; }


        }
    }
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            // Postavke za seedanje uloga (eng.: roles) i glavnog administratora

            // Tablica AspNetRoles - Identity klasa IdentityRole
            string adminRoleId = "6217999e-a9fb-448b-b163-e2305fc44f50";
            string adminRoleTitle = "Admin";
            string customerRoleId = "0e71d461-63e3-4aa5-be93-d701a5a1f913";
            string customerRoleTitle = "Customer";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = adminRoleTitle,
                    NormalizedName = adminRoleTitle.ToUpper()
                },
                new IdentityRole()
                {
                    Id = customerRoleId,
                    Name = customerRoleTitle,
                    NormalizedName = customerRoleTitle.ToUpper()
                }
            );

            // Tablica AspNetUsers - Identity klasa ApplicationUser (izvorna: IdentityUser)
            string adminId = "66412151-dd0c-4b69-82c8-0f4256e78f00";
            string admin = "mico@admin.com"; /// i korisničko ime i email vrijednost
            string adminFirstName = "Mićo";
            string adminLastName = "Programerić";
            string adminPassword = "secret";
            string adminAddress = "Stara Cesta bb";

            // Za Hash lozinke
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = adminId,
                    UserName = admin,
                    NormalizedUserName = admin.ToUpper(),
                    Email = admin,
                    NormalizedEmail = admin.ToUpper(),
                    FirstName = adminFirstName,
                    LastName = adminLastName,
                    Address = adminAddress,
                    PasswordHash = hasher.HashPassword(null, adminPassword)
                }
            );

            // Tablica AspNetUserRoles - Identity klasa IdentityUserRole<string> (veza između Users i Roles)
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = adminId,
                    RoleId = adminRoleId
                }
            );



        }
    }
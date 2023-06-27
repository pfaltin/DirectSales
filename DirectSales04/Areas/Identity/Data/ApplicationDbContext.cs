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


        }
    }
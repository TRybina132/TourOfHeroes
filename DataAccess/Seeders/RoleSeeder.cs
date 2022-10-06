using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    public static class RoleSeeder
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            IdentityRole<int> admin = new IdentityRole<int>
            {
                Id = 1,
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "dog"
            };

            IdentityRole<int> user = new IdentityRole<int>
            {
                Id = 2,
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = "goat"
            };

            IdentityRole<int> reptiloid = new IdentityRole<int>
            {
                Id = 4,
                Name = "reptiloid",
                NormalizedName = "REPTILOID",
                ConcurrencyStamp = "lizard"
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(admin, user, reptiloid);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    internal static class HeroSeeder
    {
        internal static void SeedHeroes(this ModelBuilder modelBuilder)
        {
            Hero andromeda = new Hero { Name = "Andromeda", Id = 200 };
            Hero mercury = new Hero { Name = "Mercury", Id = 400 };
            Hero lilith = new Hero { Name = "Lilith", Id = 244 };

            modelBuilder.Entity<Hero>()
                .HasData(andromeda, mercury, lilith);
        }
    }
}

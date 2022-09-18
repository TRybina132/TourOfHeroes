using DataAccess.Configurations;
using DataAccess.Context.Interceptors;
using DataAccess.Seeders;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public sealed class TourContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(HeroConfiguration).Assembly);
            builder.SeedUsers();
        }

        public TourContext(DbContextOptions options) : base(options) { }
    }
}

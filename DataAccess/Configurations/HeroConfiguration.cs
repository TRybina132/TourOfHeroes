using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Configurations
{
    internal class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.HasKey(hero => hero.Id);

            builder.HasOne(hero => hero.User)
                .WithMany(user => user.Heroes)
                .HasForeignKey(hero => hero.UserId);
        }
    }
}

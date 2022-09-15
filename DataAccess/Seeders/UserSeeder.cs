using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders
{
    internal static class UserSeeder
    {
        internal static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            string karenUsername = "6_Ikaren";
            string karenPassword = "iLoveDogs222";

            string markUsername = "Mark222";
            string markPassword = "Iam20040922";

            string nancyUsername = "nancy_2200";
            string nancyPassword = "nancy20002";

            User karen = new User()
            {
                Id = 1,
                UserName = karenUsername,
                NormalizedUserName = karenUsername.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            User nancy = new User()
            {
                Id = 2,
                UserName = nancyUsername,
                NormalizedUserName = nancyUsername.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            User mark = new User()
            {
                Id = 3,
                UserName = markUsername,
                NormalizedUserName = markUsername.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            nancy.PasswordHash = hasher.HashPassword(nancy, nancyPassword);
            karen.PasswordHash = hasher.HashPassword(karen, karenPassword);
            mark.PasswordHash = hasher.HashPassword(mark, markPassword);

            modelBuilder.Entity<User>().HasData(karen, nancy, mark);
        }
    }
}

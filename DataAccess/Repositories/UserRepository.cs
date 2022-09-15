using DataAccess.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TourContext tourContext) : base(tourContext) { }

        public async Task<User?> GetByUsername(string username)
        {
            var user = await dbSet.FirstOrDefaultAsync(users => users.UserName == username);

            return user;
        }
    }
}

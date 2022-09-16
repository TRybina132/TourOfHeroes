using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.ServicesAbstractions;

namespace Service.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync
                (asNoTracking: true,
                include: query => query.Include(user => user.Heroes));

            return users.ToList();
        }

        public async Task<User> GetByUsername(string username)
        {
            var user = await userRepository.GetByUsername(username);

            return user ?? throw new EntityNotFoundException($"There no user with username: {username}");
        }

        public async Task AddUser(User user)
        {
            await userRepository.InsertAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }
}

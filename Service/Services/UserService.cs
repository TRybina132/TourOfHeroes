using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.ServicesAbstractions;

namespace Service.Services
{
    internal class UserService : IUserService, IDisposable
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        public UserService(
            IUserRepository userRepository,
            UserManager<User> userManager)
        {
            this.userManager = userManager;
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

        public async Task AddUser(User user, string password) =>
             await userManager.CreateAsync(user, password);

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
}

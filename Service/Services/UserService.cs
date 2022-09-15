using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
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

        public async Task<User> GetByUsername(string username)
        {
            var user = await userRepository.GetByUsername(username);

            return user ?? throw new EntityNotFoundException($"There no user with username: {username}");
        }
    }
}

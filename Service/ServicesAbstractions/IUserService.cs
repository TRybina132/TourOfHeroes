using Domain.Entities;

namespace Service.ServicesAbstractions
{
    public interface IUserService
    {
        Task<User> GetByUsername(string username);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user, string password);
    }
}

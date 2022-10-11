using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsername(string username);
        Task<List<User>> GetUsersForPlanet(int planetId);
    }
}

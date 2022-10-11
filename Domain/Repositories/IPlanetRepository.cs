using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPlanetRepository : IRepository<Planet>
    {
        Task<Planet?> GetByName(string name);
    }
}

using Domain.Entities;

namespace Service.ServicesAbstractions
{
    public interface IPlanetService
    {
        Task<List<Planet>> GetAllPlanets();
        Task<List<User>> GetUsersForPlanet(int planetId);
        Task<Planet> GetPlanetById(int id);
        Task<Planet> GetPlanetByName(string name);
        Task AddPlanet(Planet planet);
    }
}

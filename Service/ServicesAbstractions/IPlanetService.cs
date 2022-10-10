using Domain.Entities;

namespace Service.ServicesAbstractions
{
    public interface IPlanetService
    {
        Task<List<Planet>> GetAllPlanets();
        Task<Planet> GetPlanetById(int id);
        Task<Planet> GetPlanetByName(string name);
        Task AddPlanet(Planet planet);
    }
}

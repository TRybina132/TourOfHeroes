using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Service.ServicesAbstractions;

namespace Service.Services
{
    internal class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository planetRepository;

        public PlanetService(IPlanetRepository planetRepository)
        {
            this.planetRepository = planetRepository;
        }

        public async Task<List<Planet>> GetAllPlanets()
        {
            var planets = await planetRepository.GetAllAsync(asNoTracking: true);
            return planets.ToList();
        }

        public async Task<Planet> GetPlanetById(int id)
        {
            Planet? planet = await planetRepository.GetById(id);
            return planet ?? throw new EntityNotFoundException("Planet with id: {id} not found");
        }

        public async Task AddPlanet(Planet planet)
        {
            await planetRepository.InsertAsync(planet);
            await planetRepository.SaveChangesAsync();
        }

        public Task<Planet> GetPlanetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

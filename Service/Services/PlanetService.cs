using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Service.ServicesAbstractions;

namespace Service.Services
{
    internal class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository planetRepository;
        private readonly IUserRepository userRepository;
        public PlanetService(IPlanetRepository planetRepository, IUserRepository userRepository)
        {
            this.planetRepository = planetRepository;
            this.userRepository = userRepository;   
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

        public async Task<List<User>> GetUsersForPlanet(int planetId) =>
            await userRepository.GetUsersForPlanet(planetId);

        public async Task AddPlanet(Planet planet)
        {
            await planetRepository.InsertAsync(planet);
            await planetRepository.SaveChangesAsync();
        }

        public async Task<Planet> GetPlanetByName(string name)
        {
            Planet? planet = await planetRepository.GetByName(name);
            return planet ?? throw new EntityNotFoundException($"Planet with name: {name} not found");
        }
    }
}

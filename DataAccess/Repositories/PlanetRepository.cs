using DataAccess.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository(TourContext tourContext) : base(tourContext) { }

        public async Task<Planet?> GetByName(string name) =>
            await dbSet.FirstOrDefaultAsync(planet => planet.Name == name);
    }
}

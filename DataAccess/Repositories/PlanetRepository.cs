using DataAccess.Context;
using Domain.Entities;
using Domain.Repositories;

namespace DataAccess.Repositories
{
    internal class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository(TourContext tourContext) : base(tourContext) { }
    }
}

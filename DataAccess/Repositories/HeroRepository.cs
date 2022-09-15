using DataAccess.Context;
using Domain.Entities;
using Domain.Repositories;

namespace DataAccess.Repositories
{
    internal class HeroRepository : Repository<Hero>, IHeroRepository
    {
        public HeroRepository(TourContext tourContext) : base(tourContext)
        {

        }
    }
}

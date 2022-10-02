using Domain.Entities;

namespace Service.ServicesAbstractions
{
    public interface IHeroService
    {
        Task<IList<Hero>> GetAllHeroes();
        Task AddHero(Hero hero, int? userId = null);
        Task<Hero> GetHeroById(int heroId);
        Task UpdateHero(Hero hero);
        Task RemoveHero(int heroId);
        Task<IList<Hero>> GetHeroesForUser(int? userId);
    }
}

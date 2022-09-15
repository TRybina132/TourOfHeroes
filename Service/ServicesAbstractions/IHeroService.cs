using Domain.Entities;

namespace Service.ServicesAbstractions
{
    public interface IHeroService
    {
        Task<IList<Hero>> GetAllHeroes();
        Task AddHero(Hero hero);
        Task<Hero> GetHeroById(int heroId);
        Task UpdateHero(Hero hero);
        Task RemoveHero(int heroId);
    }
}

using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.ServicesAbstractions;

namespace Service.Services
{
    //  ᓚᘏᗢ We add internal modifier cause we should use only
    //          abstractions in our projects
    internal class HeroService : IHeroService, IDisposable
    {
        private readonly IHeroRepository heroRepository;

        public HeroService(IHeroRepository heroRepository)
        {
            this.heroRepository = heroRepository;
        }

        public async Task<IList<Hero>> GetAllHeroes() =>
            await heroRepository.GetAllAsync(
                asNoTracking: true,
                include: query => query.Include(hero => hero.User));

        public async Task<IList<Hero>> GetHeroesForUser(int? userId) =>
            userId != null ?
            await heroRepository.GetAllAsync(
                asNoTracking: true,
                include: query => query.Include(hero => hero.User),
                filter: hero => hero.UserId == userId)
            : throw new Exception("Can't get current user id!");

        public async Task<Hero> GetHeroById(int heroId)
        {
            var hero = await heroRepository.GetById(
                heroId,
                include: query => query.Include(hero => hero.User));

            return hero ?? throw new EntityNotFoundException($"There no such hero with id: {heroId}");
        }

        public async Task AddHero(Hero hero, int? userId = null)
        {
            if (userId != null)
                hero.UserId = userId;

            await heroRepository.InsertAsync(hero);
            await heroRepository.SaveChangesAsync();
        }

        public async Task RemoveHero(int heroId)
        {
            Hero hero = await GetHeroById(heroId);

            heroRepository.Delete(hero);
            await heroRepository.SaveChangesAsync();
        }

        public async Task UpdateHero(Hero hero)
        {
            heroRepository.Update(hero);
            await heroRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose hero service!");
        }
    }
}

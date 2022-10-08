using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Repositories.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlanetRepository, PlanetRepository>();
        }
    }
}

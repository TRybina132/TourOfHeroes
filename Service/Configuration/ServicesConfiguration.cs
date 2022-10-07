using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.ServicesAbstractions;

namespace Service.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IHeroService, HeroService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}

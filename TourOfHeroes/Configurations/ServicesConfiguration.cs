using DataAccess.Repositories.Configuration;
using Domain.Entities;
using MediatR;
using Messaging.MediatR.Handlers;
using Messaging.Producers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Presentation.Controllers;
using Presentation.Profiles;
using Service.Configuration;
using Service.ServicesAbstractions;
using TourOfHeroes.Middleware;

namespace TourOfHeroes.Configurations
{
    //  ᓚᘏᗢ Service scope - Container(includes ServiceProvider) that
    //          created one per request (here Transient and Scoped will be stored)
    //  ᓚᘏᗢ Root scope - global container (one per server) here singleton
    //          services will be stored
    //
    //  🌈 Services will be disposed only when ServiceProvider disposed(Services provider
    //      is disposed per request)💖
    internal static class ServicesConfiguration
    {
        internal static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageProducer, HeroMessageProducer>();

            services.AddScoped<ExceptionMiddleware>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthorization(options =>
            {
                //  ᓚᘏᗢ Setting up default schema cause it doesn't want to use cookies as default
                var defaultAuthBuilder = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
                defaultAuthBuilder = defaultAuthBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthBuilder.Build();
            });
            services.AddCustomServices();
            services.AddRepositories();
            services.AddControllers();

            services.AddAutoMapper(typeof(HeroProfile));
            services.AddMediatR(typeof(RegisterUserHandler));

            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();

            services.AddMediatR(typeof(IHeroService).Assembly);

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                //  ᓚᘏᗢ How to proceed cookies
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,options =>
                {
                        //  ᓚᘏᗢ What to do if authentication failed
                        options.Events.OnRedirectToLogin = (context) =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        };

                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                        options.SlidingExpiration = true;
                });
        }

        internal static void AddCors(this IServiceCollection services, IConfigurationSection corsConfig)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsConfig["Name"],
                    policy =>
                    {
                        policy.WithOrigins(corsConfig["Origin"]);
                        policy.AllowCredentials();
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
            });
        }
    }
}

using DataAccess.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApiTests.Factories
{
    public class TestWebAppFactory<TEntryPoint> 
        : WebApplicationFactory<Program>
        where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                ServiceDescriptor? descriptor = services
                    .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<TourContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                //  ᓚᘏᗢ Creating temporary in-memory database
                services.AddDbContext<TourContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTourOfHeroes");
                });
                
                ServiceProvider serviceProvider = services.BuildServiceProvider();

                //  ᓚᘏᗢ DB context is scoped so we need this class to provide it
                using var scope = serviceProvider.CreateScope();
                using TourContext dbContext = scope.ServiceProvider.GetRequiredService<TourContext>();
                try
                {
                    if (dbContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                        dbContext.Database.Migrate();

                    //  ᓚᘏᗢ Creating database if there no database
                    dbContext.Database.EnsureCreated();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            });
            //base.ConfigureWebHost(builder);
        }
    }
}

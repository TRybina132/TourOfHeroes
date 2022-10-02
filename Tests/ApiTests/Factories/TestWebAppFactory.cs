using DataAccess.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                

            });
            //base.ConfigureWebHost(builder);
        }
    }
}

using BlobStorageManager.Options;
using BlobStorageManager.Repositories;
using BlobStorageManager.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlobStorageManager.Configuration
{
    public static class BlobConfiguration
    {
        public static void AddBlobRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAzureRepository, AzureRepository>();
        }
    }
}

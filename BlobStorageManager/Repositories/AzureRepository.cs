using Azure.Storage.Blobs;
using BlobStorageManager.Models;
using BlobStorageManager.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TourOfHeroes.Options;

namespace BlobStorageManager.Repositories
{
    internal class AzureRepository : IAzureRepository
    {
        private readonly BlobStorageOptions storageOptions;
        private readonly BlobContainerClient blobContainerClient;

        public AzureRepository(IOptions<BlobStorageOptions> storageOptions)
        {
            this.storageOptions = storageOptions.Value;
            blobContainerClient = new BlobContainerClient(this.storageOptions.BlobConnectionString, this.storageOptions.BlobContainerName);
        }

        public Task<BlobItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BlobItem> Download(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<BlobResponse> Delete(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<BlobResponse> Upload(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}

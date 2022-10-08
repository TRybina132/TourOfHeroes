using BlobStorageManager.Models;
using BlobStorageManager.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;

namespace BlobStorageManager.Repositories
{
    internal class AzureRepository : IAzureRepository
    {
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

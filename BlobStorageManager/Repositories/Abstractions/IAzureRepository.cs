using BlobStorageManager.Models;
using Microsoft.AspNetCore.Http;

namespace BlobStorageManager.Repositories.Abstractions
{
    public interface IAzureRepository
    {
        Task<BlobItem> GetAll();
        Task<BlobResponse> Upload(IFormFile file);
        Task<BlobItem> Download(string fileName);
        Task<BlobResponse> Delete(string fileName);
    }
}

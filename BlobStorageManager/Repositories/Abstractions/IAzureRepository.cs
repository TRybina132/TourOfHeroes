using BlobStorageManager.Models;
using Microsoft.AspNetCore.Http;

namespace BlobStorageManager.Repositories.Abstractions
{
    public interface IAzureRepository
    {
        Task<List<BlobObject>> GetAll();
        Task<BlobResponse> Upload(IFormFile file);
        Task<BlobResponse> Download(string fileName);
        Task<BlobResponse> Delete(string fileName);
    }
}

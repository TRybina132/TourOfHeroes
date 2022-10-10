using BlobStorageManager.Models;
using BlobStorageManager.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("/api/response")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IAzureRepository azureRepository;

        public BlobController(IAzureRepository azureRepository)
        {
            this.azureRepository = azureRepository;
        }

        [HttpGet]
        public async Task<List<BlobObject>> GetAll()
        {
            return await azureRepository.GetAll();
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> Download([FromRoute] string fileName)
        {
            BlobResponse response = await azureRepository.Download(fileName);
            return response != null ?
                File(response.Blob?.Content?.Content.ToArray(), response?.Blob?.ContentType)
                : StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }

        [HttpPost]
        public async Task<BlobResponse> UploadFile(IFormFile file)
        {
            return await azureRepository.Upload(file);
        }
    }
}

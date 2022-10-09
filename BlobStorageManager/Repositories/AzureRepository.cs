using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobStorageManager.Models;
using BlobStorageManager.Options;
using BlobStorageManager.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;

namespace BlobStorageManager.Repositories
{
    internal class AzureRepository : IAzureRepository
    {
        private readonly BlobStorageOptions storageOptions;
        private readonly BlobContainerClient blobContainerClient;

        private BlobObject GenerateBlobObject(BlobItem blob) =>
            new BlobObject
            {
                Uri = $"{blobContainerClient.Uri}/{blob.Name}",
                Name = blob.Name,
                ContentType = blob.Properties.ContentType
            };

        public AzureRepository(IOptions<BlobStorageOptions> storageOptions)
        {
            this.storageOptions = storageOptions.Value;
            blobContainerClient = new BlobContainerClient(this.storageOptions.BlobConnectionString, this.storageOptions.BlobContainerName);
        }

        public async Task<List<BlobObject>> GetAll()
        {
            List<BlobObject> blobs = new List<BlobObject>();
            await foreach (BlobItem blob in blobContainerClient.GetBlobsAsync())
                blobs.Add(GenerateBlobObject(blob));

            return blobs;
        }

        public async Task<BlobResponse> Download(string fileName)
        {
            try
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                if(await blobClient.ExistsAsync())
                {
                    Stream data = await blobClient.OpenReadAsync();
                    var content = await blobClient.DownloadContentAsync();

                    BlobObject blob = new BlobObject
                    {
                        Content = content.Value,
                        Name = fileName,
                        ContentType = content.Value.Details.ContentType
                    };

                    return new BlobResponse
                    {
                        Error = false,
                        Blob = blob,
                        Status = $"File: {fileName} downloaded successfuly"
                    };
                }
            }
            catch(RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return new BlobResponse
                {
                    Error = true,
                    Blob = null,
                    Status = $"Error has occured",
                    ErrorMessage = ex.Message
                };
            }

            return new BlobResponse
            {
                Error = true,
                Status = $"Error has occured"
            };
        }

        public Task<BlobResponse> Delete(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<BlobResponse> Upload(IFormFile file)
        {
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.Name);

            await using (Stream? data = file.OpenReadStream())
                await blobClient.UploadAsync(data);

            BlobResponse response = new BlobResponse
            {
                Status = $"File {file.FileName} Uploaded Successfully",
                Error = false
            };
            response.Blob.Uri = blobClient.Uri.AbsoluteUri;
            response.Blob.Name = blobClient.Name;

            return response;
        }
    }
}

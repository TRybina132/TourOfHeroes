using Azure.Storage.Blobs.Models;

namespace BlobStorageManager.Models
{
    public class BlobObject
    {
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public string? ContentType { get; set; }
        public BlobDownloadResult? Content { get; set; }
    }
}

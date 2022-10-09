namespace BlobStorageManager.Models
{
    public class BlobResponse
    {
        public string? Status { get; set; }
        public bool Error { get; set; }
        public string? ErrorMessage { get; set; }
        public BlobObject Blob { get; set; }

        public BlobResponse()
        {
            Blob = new BlobObject();
        }
    }
}

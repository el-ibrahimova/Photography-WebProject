using Azure.Storage.Blobs;
using Photography.WebAPI.Interface;

namespace Photography.WebAPI.Service
{
    public class BlobService:IBlobService 
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> UploadFileAsync(IFormFile file, string containerName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                if (!await containerClient.ExistsAsync())
                {
                    throw new Exception($"Container {containerName} does not exist.");
                }

                var blobClient = containerClient.GetBlobClient(file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return false;
            }
        }
    }
}
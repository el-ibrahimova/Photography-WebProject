namespace Photography.WebAPI.Interface
{
    public interface IBlobService
    {
        Task<bool> UploadFileAsync(IFormFile file, string containerName);
    }
}

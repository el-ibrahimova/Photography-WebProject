namespace Photography.Core.ViewModels.Photo
{
    public class DeleteViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string UploadedAt { get; set; } = null!;
        public string? UserOwnerId { get; set; } 

        public string? Owner { get; set; } 
    }
}

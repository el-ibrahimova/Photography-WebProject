namespace Photography.Core.ViewModels.Photo
{
    public class DeleteViewModel
    {
        public string Id { get; set; } = null!;
        public string? TagUser { get; set; } 
        public string UploadedAt { get; set; } = null!;
        public string? DeletedAt { get; set; }
        public string UserOwnerId { get; set; } = null!;
        public string Owner { get; set; } = null!;
    }
}

namespace Photography.Core.ViewModels.Photo
{
    using Infrastructure.Data.Models;
    public class DetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string? TagUser { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }
        public string UploadedAt { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public bool IsPrivate { get; set; }
        public Guid UserOwnerId { get; set; }
        public ICollection<string> Categories { get; set; } = new HashSet<string>();
    }
}

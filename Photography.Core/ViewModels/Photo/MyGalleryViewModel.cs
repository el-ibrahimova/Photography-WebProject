namespace Photography.Core.ViewModels.Photo
{
    public class MyGalleryViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public bool IsPrivate { get; set; }

        public string UserOwnerId { get; set; } = null!;
    }
}

namespace Photography.Core.ViewModels.Photo
{
    public class GalleryPhotoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public bool IsPrivate { get; set; }
    }
}

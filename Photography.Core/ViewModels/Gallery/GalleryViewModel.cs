﻿namespace Photography.Core.ViewModels.Gallery
{
    public class GalleryViewModel
    {
        public string Id { get; set; } = null!;
        public string? TagUser { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; } = null!;
    }
}

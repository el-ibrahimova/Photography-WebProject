﻿namespace Photography.Core.ViewModels.Photo
{
    public class GalleryViewModel
    {
        public string Id { get; set; } = null!;
        public string? TagUser { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public bool IsPrivate { get; set; }
        public string? UserOwnerId { get; set; } = null!;
    }
}

﻿using Photography.Core.ViewModels.Gallery;

namespace Photography.Core.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<GalleryViewModel>> GetGalleryAsync();
    }
}

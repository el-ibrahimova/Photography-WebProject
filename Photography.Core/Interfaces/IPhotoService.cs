using Photography.Core.ViewModels.Photo;

namespace Photography.Core.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<GalleryViewModel>> GetGalleryAsync();
    }
}

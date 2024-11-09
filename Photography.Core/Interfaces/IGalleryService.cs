using Photography.Core.ViewModels.Gallery;

namespace Photography.Core.Interfaces
{
    public interface IGalleryService:IBaseService
    {
        Task<IEnumerable<GalleryViewModel>> GetGalleryAsync();
        Task<IEnumerable<MyGalleryViewModel>> GetPrivateGalleryAsync(Guid userId);
    }
}

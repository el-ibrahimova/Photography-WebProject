using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoService:IBaseService
    {
        Task<IEnumerable<GalleryViewModel>> GetGalleryAsync();
        Task<IEnumerable<MyGalleryViewModel>> GetPrivateGalleryAsync(Guid userId);
        Task<Photo?> GetPhotoByIdAsync(Guid photoIdGuid);
        Task<AddPhotoViewModel>GetAddPhotoAsync();
        Task<bool>AddPhotoAsync(AddPhotoViewModel model, string userId);
        Task IncreaseRatingAsync(Guid photoIdGuid, Guid userIdGuid);
        Task<bool> HasUserRatedAsync(Guid photoIdGuid, Guid userIdGuid);
        Task<DetailsViewModel?> GetPhotoDetailsAsync(Guid photoGuid);
        Task<ICollection<FavoriteViewModel>> GetFavoritePhotosAsync(Guid userId);
        Task <bool> AddPhotoToFavoritesAsync(Guid userGuid, Guid photoGuid);
        Task <bool> RemovePhotoFromFavoritesAsync(string userId, string photoId);
        Task<EditPhotoViewModel?> GetPhotoToEditAsync(Guid photoGuid);
        Task<bool> EditPhotoAsync(EditPhotoViewModel model);
        Task <DeleteViewModel?>GetPhotoDelete(Guid photoId);
        Task<bool> DeletePhotoAsync(string photoId);

        Task<ICollection<CategoryViewModel>> GetCategoriesAsync();
        Task<ICollection<UserViewModel>> GetAllUsersAsync();

        Task<ICollection<AllPhotosViewModel>> GetAllPhotosAsync();
    }
}

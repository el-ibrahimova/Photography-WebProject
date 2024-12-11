using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoService:IBaseService
    {
        Task<ICollection<GalleryViewModel>> GetGalleryAsync(GalleryWithSearchFilterViewModel model);
        Task<ICollection<GalleryViewModel>> GetPrivateGalleryAsync(GalleryWithSearchFilterViewModel model, string userId);
        Task<Photo?> GetPhotoByIdAsync(string photoId);
        Task<AddPhotoViewModel>GetAddPhotoAsync();
        Task<bool>AddPhotoAsync(AddPhotoViewModel model, string userId);
        Task IncreaseRatingAsync(string photoId, string userId);
        Task<bool> HasUserRatedAsync(string photoId, string userId);
        Task<DetailsViewModel?> GetPhotoDetailsAsync(string photoId);
        Task<ICollection<FavoriteViewModel>> GetFavoritePhotosAsync(string userId);
        Task <bool> AddPhotoToFavoritesAsync(string userId, string photoId);
        Task <bool> RemovePhotoFromFavoritesAsync(string userId, string photoId);
        Task<bool> IsPhotoOwnedByPhotographerAsync(string photoId, string userId);
        Task<EditPhotoViewModel?> GetPhotoToEditAsync(string photoId);
        Task<bool> EditPhotoAsync(EditPhotoViewModel model);
        Task <DeleteViewModel?>GetPhotoDelete(string photoId);
        Task<bool> DeletePhotoAsync(string photoId);

        Task<ICollection<CategoryViewModel>> GetCategoriesAsync();
        Task<ICollection<UserViewModel>> GetAllUsersAsync();

        Task<ICollection<AllPhotosViewModel>> GetAllPhotosAsync(ManageWithSearchFilterViewModel model);
        Task<int> GetPhotosCountByFilterAsync(GalleryWithSearchFilterViewModel inputModel);
        Task<int> GetPrivatePhotosCountByFilterAsync(GalleryWithSearchFilterViewModel inputModel, string userId);
        Task<int> GetManagePhotosCountByFilterAsync(ManageWithSearchFilterViewModel inputModel);
    }
}

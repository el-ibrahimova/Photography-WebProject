using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoService:IBaseService
    {
        Task<Photo?> GetPhotoByIdAsync(Guid photoIdGuid);
        Task<AddPhotoViewModel>GetAddPhotoAsync();
        Task<bool>AddPhotoAsync(AddPhotoViewModel model, string userId);
        Task IncreaseRatingAsync(Guid photoIdGuid, Guid userIdGuid);
        Task<bool> HasUserRatedAsync(Guid photoIdGuid, Guid userIdGuid);
        Task<DetailsViewModel> GetPhotoDetailsAsync(Guid photoGuid);
        Task<ICollection<FavoriteViewModel>> GetFavoritePhotosAsync(string userId);
        Task AddPhotoToFavoritesAsync(Guid userGuid, Guid photoGuid);
        Task RemovePhotoFromFavoritesAsync(string userId, string photoId);
        Task<EditPhotoViewModel> GetPhotoToEditAsync(Guid photoGuid);
        Task<bool> EditPhotoAsync(EditPhotoViewModel model);
        Task <DeleteViewModel>GetPhotoDelete(string photoId);
        Task<Photo> DeletePhotoAsync(string photoId);

        Task<ICollection<CategoryViewModel>> GetCategoriesAsync();
        Task<ICollection<UserViewModel>> GetAllUsersAsync();

        Task<ICollection<AllPhotosViewModel>> GetAllPhotosAsync();
    }
}

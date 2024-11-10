using Photography.Core.ViewModels.Gallery;
using Photography.Core.ViewModels.Photo;

namespace Photography.Core.Interfaces
{
    public interface IPhotoService
    {
        Task<AddPhotoViewModel>GetAddPhotoAsync();
        Task AddPhotoAsync(AddPhotoViewModel model, string userId);
        Task IncreaseRatingAsync(Guid photoIdGuid, Guid userIdGuid);
        Task<DetailsViewModel> GetPhotoDetailsAsync(Guid photoGuid);



        Task<ICollection<CategoryViewModel>> GetCategoriesAsync();
        Task<ICollection<UserViewModel>> GetAllUsersAsync();
    }
}

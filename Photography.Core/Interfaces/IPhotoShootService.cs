using Photography.Core.ViewModels.PhotoShoot;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoShootService:IBaseService
    {
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync();
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsForManageAsync();
        Task <bool> AddPhotoShootAsync(AddPhotoShootViewModel model);
        Task<bool> HasUserDeclaredParticipationAsync(string photoShootId, string userId);
        Task<bool> AddParticipantToPhotoShoot(string photoId, string userId);
        Task<IEnumerable<UserPhotoShootsViewModel>> GetUserPhotoShootsAsync(string userId);
        Task<bool> RemoveUserFromParticipation(string userId, string photoId);

        Task<EditPhotoShootViewModel?> GetPhotoShootToEditAsync(string photoShootId);
        Task<bool> EditPhotoShootAsync(EditPhotoShootViewModel model);
        
        Task<PhotoShoot?> GetPhotoShootByIdAsync(string photoShootId);

        Task<DeletePhotoShootViewModel?> GetPhotoShootToDelete(string photoShootId);
        Task<bool> DeletePhotoShootAsync(string photoShootId);

        Task <Guid> GetPhotographerIdByUserIdAsync(string userId);
        Task <bool> IsPhotoShootOwnedByPhotographerAsync(string photoShootIs, string userId);
    }
}

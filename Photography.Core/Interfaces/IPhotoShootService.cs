using Photography.Core.ViewModels.PhotoShoot;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoShootService:IBaseService
    {
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync();
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsForManageAsync(Guid userId);
        Task <bool> AddPhotoShootAsync(AddPhotoShootViewModel model);
        Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid);
        Task<bool> AddParticipantToPhotoShoot(Guid photoIdGuid, Guid userIdGuid);
        Task<IEnumerable<UserPhotoShootsViewModel>> GetUserPhotoShootsAsync(Guid userId);
        Task<bool> RemoveUserFromParticipation(string userId, string photoId);

        Task<EditPhotoShootViewModel?> GetPhotoShootToEditAsync(Guid photoShootId, Guid photographerId);
        Task<bool> EditPhotoShootAsync(EditPhotoShootViewModel model);
        
        Task<PhotoShoot?> GetPhotoShootByIdAsync(Guid photoIdGuid);

        Task<DeletePhotoShootViewModel?> GetPhotoShootToDelete(Guid photoShootId);
        Task<bool> DeletePhotoShootAsync(string photoShootId);

        Task <Guid> GetPhotographerIdByUserIdAsync(Guid userId);

    }
}

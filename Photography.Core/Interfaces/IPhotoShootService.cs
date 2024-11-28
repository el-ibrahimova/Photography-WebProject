using Photography.Core.ViewModels.Photo;
using Photography.Core.ViewModels.PhotoShoot;

namespace Photography.Core.Interfaces
{
    public interface IPhotoShootService:IBaseService
    {
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync();
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsForManageAsync();

        Task <bool> AddPhotoShootAsync(AddPhotoShootViewModel model);

        Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid);
        Task AddParticipantToPhotoShoot(Guid photoIdGuid, Guid userIdGuid);
    }
}

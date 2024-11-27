using Photography.Core.ViewModels.PhotoShoot;

namespace Photography.Core.Interfaces
{
    public interface IPhotoShootService:IBaseService
    {
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync();

        Task <bool> AddPhotoShootAsync(AddPhotoShootViewModel model);

        Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid);
    }
}

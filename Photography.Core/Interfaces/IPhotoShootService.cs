﻿using Photography.Core.ViewModels.PhotoShoot;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoShootService:IBaseService
    {
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync();
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsForManageAsync(string userId);
        Task <bool> AddPhotoShootAsync(AddPhotoShootViewModel model);
        Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid);
        Task<bool> AddParticipantToPhotoShoot(Guid photoIdGuid, Guid userIdGuid);
        Task<IEnumerable<UserPhotoShootsViewModel>> GetUserPhotoShootsAsync(string userId);
        Task<bool> RemoveUserFromParticipation(string userId, string photoId);

        Task<EditPhotoShootViewModel?> GetPhotoShootToEditAsync(string photoShootId, string photographerId);
        Task<bool> EditPhotoShootAsync(EditPhotoShootViewModel model);
        
        Task<PhotoShoot?> GetPhotoShootByIdAsync(Guid photoIdGuid);

        Task<DeletePhotoShootViewModel?> GetPhotoShootDelete(string photoShootId);
        Task<bool> DeletePhotoShootAsync(string photoShootId);

        Task <Photographer?> GetPhotographerByUserIdAsync(string userId);

    }
}

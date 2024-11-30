﻿using Photography.Core.ViewModels.Photo;
using Photography.Core.ViewModels.PhotoShoot;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IPhotoShootService:IBaseService
    {
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsAsync();
        Task<IEnumerable<AllPhotoShootsViewModel>> GetAllPhotoShootsForManageAsync();
        Task <bool> AddPhotoShootAsync(AddPhotoShootViewModel model);
        Task<bool> HasUserDeclaredParticipationAsync(Guid photoShootIdGuid, Guid userIdGuid);
        Task AddParticipantToPhotoShoot(Guid photoIdGuid, Guid userIdGuid);
      
        
        Task<EditPhotoShootViewModel> GetPhotoShootToEditAsync(Guid photoShootGuid);
        Task<bool> EditPhotoShootAsync(EditPhotoShootViewModel model);
        
        Task<PhotoShoot?> GetPhotoShootByIdAsync(Guid photoIdGuid);
    }
}

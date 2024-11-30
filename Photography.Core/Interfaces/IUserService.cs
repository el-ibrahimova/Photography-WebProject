﻿using Photography.Core.ViewModels.Admin.UserManagement;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
        Task<bool> UserExistByIdAsync(Guid userId);
        Task<bool> AssignUserToRoleAsync(Guid userId, string roleName);
        Task<bool> RemoveUserRoleAsync(Guid userId, string roleName);

        Task<bool> DeleteUserAsync(Guid userId);
        Task<bool> MakeUserPhotographerAsync(Guid userId, string brandName);
    }
}

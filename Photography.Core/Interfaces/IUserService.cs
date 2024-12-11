using Photography.Core.ViewModels.Admin.UserManagement;
using Photography.Core.ViewModels.UserProfile;

namespace Photography.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
        Task<bool> UserExistByIdAsync(string userId);
        Task<bool> IsUserPhotographerAsync(string userId);
        Task<bool> AssignUserToRoleAsync(string userId, string roleName);
        Task<bool> RemoveUserRoleAsync(string userId, string roleName);

        Task<bool> DeleteUserAsync(string userId);
        Task<bool> MakeUserPhotographerAsync(string userId, string brandName);
        Task<bool> RemoveUserFromPhotographerAsync(string userId);
    }
}

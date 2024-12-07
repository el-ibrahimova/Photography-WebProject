using Photography.Controllers;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Admin.UserManagement;

namespace Photography.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Common.ApplicationConstants;

    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class UserManagementController : BaseController
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllUsersViewModel> allUsers = await userService.GetAllUsersAsync();

            return View(allUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool userExist = await userService
                .UserExistByIdAsync(userGuid);

            if (!userExist)
            {
                return RedirectToAction(nameof(Index));
            }

            bool assignResult = await userService
                .AssignUserToRoleAsync(userGuid, role);

            if (!assignResult)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool userExist = await userService
                .UserExistByIdAsync(userGuid);

            if (!userExist)
            {
                return RedirectToAction(nameof(Index));
            }

            bool removeResult = await userService
                .RemoveUserRoleAsync(userGuid, role);

            if (!removeResult)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool userExists = await userService
                .UserExistByIdAsync(userGuid);
            if (!userExists)
            {
                return RedirectToAction(nameof(Index));
            }

            bool isUserPhotographer = await userService.IsUserPhotographerAsync(userGuid);

            if (isUserPhotographer)
            {
                bool result = await userService.RemoveUserFromPhotographerAsync(userGuid);
                if (!result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            bool removeResult = await userService
                .DeleteUserAsync(userGuid);
            if (!removeResult)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MakePhotographer(Guid userId, string brandName)
        {
            bool success = await userService.MakeUserPhotographerAsync(userId, brandName);

            if (!success)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemovePhotographer(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return RedirectToAction(nameof(Index));
            }

            bool userExist = await userService
                .UserExistByIdAsync(userGuid);

            if (!userExist)
            {
                return RedirectToAction(nameof(Index));
            }

            bool removeResult = await userService
                .RemoveUserFromPhotographerAsync(userGuid);

            if (!removeResult)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

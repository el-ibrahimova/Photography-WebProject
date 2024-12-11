namespace Photography.Areas.Admin.Controllers
{
    using Photography.Controllers;
    using Photography.Core.Interfaces;
    using Photography.Core.ViewModels.Admin.UserManagement;
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
                return Unauthorized();
            }

            bool userExist = await userService.UserExistByIdAsync(userId);

            if (!userExist)
            {
                return NotFound();
            }

            bool assignResult = await userService.AssignUserToRoleAsync(userId, role);

            if (!assignResult)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData[SuccessMessage] = "Успешно зададохте роля";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return Unauthorized();
            }

            bool userExist = await userService.UserExistByIdAsync(userId);

            if (!userExist)
            {
                return NotFound();
            }

            bool removeResult = await userService.RemoveUserRoleAsync(userId, role);

            if (!removeResult)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData[SuccessMessage] = "Успешно премахнахте роля";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return Unauthorized();
            }

            bool userExists = await userService.UserExistByIdAsync(userId);
            if (!userExists)
            {
                return NotFound();
            }

            bool isUserPhotographer = await userService.IsUserPhotographerAsync(userId);

            if (isUserPhotographer)
            {
                bool result = await userService.RemoveUserFromPhotographerAsync(userId);
                if (!result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            bool removeResult = await userService.DeleteUserAsync(userId);
            if (!removeResult)
            {
                TempData[ErrorMessage] = "Възникна неочаквана грешка. Потребителят не беше изтрит.";
                return RedirectToAction(nameof(Index));
            }

            TempData[SuccessMessage] = "Успешно изтрихте потребител.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> MakePhotographer(string userId, string brandName)
        {
            bool success = await userService.MakeUserPhotographerAsync(userId, brandName);

            if (!success)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData[SuccessMessage] = "Успешно направихте потребителя фотограф";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemovePhotographer(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userGuid))
            {
                return Unauthorized();
            }

            bool userExist = await userService.UserExistByIdAsync(userId);

            if (!userExist)
            {
                return NotFound();
            }

            bool removeResult = await userService.RemoveUserFromPhotographerAsync(userId);

            if (!removeResult)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData[SuccessMessage] = "Успешно премахнахте потребителя от роля на фотограф";
            return RedirectToAction(nameof(Index));
        }
    }
}

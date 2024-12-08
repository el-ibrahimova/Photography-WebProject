using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.ViewModels.UserProfile;
using Photography.Infrastructure.Data.Models;

namespace Photography.Controllers
{
    public class UserProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserProfileController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
       
    [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            string userId = GetUserId();

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return Unauthorized();
            }

            ApplicationUser? user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            UserProfileViewModel model = new UserProfileViewModel()
            {
                Id = userId,
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Phone = user.PhoneNumber!
            };

           return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> MyProfile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            user.Id = Guid.Parse(model.Id);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.Phone;

            IdentityResult result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            TempData["Success"] = "Информацията беше успешно актуализирана!";
            return RedirectToAction(nameof(MyProfile));
        }
    }

}

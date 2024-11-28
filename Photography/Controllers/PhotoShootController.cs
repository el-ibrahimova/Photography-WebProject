using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.PhotoShoot;
using static Photography.Common.ApplicationConstants;
namespace Photography.Controllers
{
    [Authorize]
    public class PhotoShootController : BaseController
    {
        private readonly IPhotoShootService photoShootService;

        public PhotoShootController(IPhotoShootService _photoShootService)
        {
            photoShootService = _photoShootService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await photoShootService.GetAllPhotoShootsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return Unauthorized();
            }

            var model = new AddPhotoShootViewModel();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotoShootViewModel model)
        {
            bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
             return this.View(model);
            }


            bool result = await this.photoShootService.AddPhotoShootAsync(model);

            if (result == false)
            {
                return this.View(model);
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            if (!User.IsInRole(AdminRoleName) && !isPhotographer)
            {
                return Unauthorized();
            }

            var photoShoots = await photoShootService.GetAllPhotoShootsForManageAsync();

            return View(photoShoots);
        }

        [HttpPost]
        public async Task<IActionResult> DeclareParticipation(string id)
        {
            string? currentUserId = GetUserId();

           Guid photoShootIdGuid;
            if (!Guid.TryParse(id, out photoShootIdGuid))
            {
                return BadRequest();
            }

            Guid userIdGuid;
            if (!Guid.TryParse(currentUserId, out userIdGuid))
            {
                return Unauthorized();
            }

            bool hasUserDeclared = await photoShootService.HasUserDeclaredParticipationAsync(photoShootIdGuid, userIdGuid);

            if (hasUserDeclared)
            {
                TempData["HasDeclared"] = true;
                return RedirectToAction("All", "PhotoShoot");
            }

            await photoShootService.AddParticipantToPhotoShoot(photoShootIdGuid, userIdGuid);

            return RedirectToAction("All", "PhotoShoot");

        }
    }
}

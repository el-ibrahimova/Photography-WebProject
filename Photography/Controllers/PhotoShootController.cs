using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.PhotoShoot;
using static Photography.Common.ApplicationConstants;
namespace Photography.Controllers
{
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
        [MustBePhotographer]
        public async Task<IActionResult> Add()
        {
            //bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return Unauthorized();
            //}

            var model = new AddPhotoShootViewModel();
            return this.View();
        }

        [HttpPost]
        [MustBePhotographer]
        public async Task<IActionResult> Add(AddPhotoShootViewModel model)
        {
            //bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return Unauthorized();
            //}

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }


            bool result = await this.photoShootService.AddPhotoShootAsync(model);

            if (result == false)
            {
                return this.View(model);
            }

            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]

        public async Task<IActionResult> Manage()
        {
            //bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            //if (!User.IsInRole(AdminRoleName) && !isPhotographer)
            //{
            //    return Unauthorized();
            //}

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

            }

            Guid userIdGuid;
            if (!Guid.TryParse(currentUserId, out userIdGuid))
            {
                return Unauthorized();
            }

            var photoShoot = await photoShootService.GetPhotoShootByIdAsync(photoShootIdGuid);
            if (photoShoot == null)
            {
                return BadRequest();
            }

            bool hasUserDeclared = await photoShootService.HasUserDeclaredParticipationAsync(photoShootIdGuid, userIdGuid);

            if (hasUserDeclared)
            {
                TempData["Message"] = $"Вече заявихте участие за фотосесия \"{photoShoot.Name}\"";
            }
            else
            {
                TempData["Message"] = $"Вие успешно се записахте за фотосесия \"{photoShoot.Name}\"";
            }

            await photoShootService.AddParticipantToPhotoShoot(photoShootIdGuid, userIdGuid);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            //bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return RedirectToAction("All", "PhotoShoot");
            //}

            Guid photoShootGuid = Guid.Empty;
            if (!photoShootService.IsGuidValid(id, ref photoShootGuid))
            {
                return RedirectToAction("All", "PhotoShoot");
            }

            var model = await photoShootService.GetPhotoShootToEditAsync(photoShootGuid);

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(EditPhotoShootViewModel model)
        {
            bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("All", "PhotoShoot");
            }

            var result = await photoShootService.EditPhotoShootAsync(model);

            if (!result)
            {
                Guid photoShootGuid = Guid.Empty;
                if (!photoShootService.IsGuidValid(model.Id, ref photoShootGuid))
                {
                    return RedirectToAction("All", "PhotoShoot");
                }

                var photoShoot = await photoShootService.GetPhotoShootToEditAsync(photoShootGuid);

                return View(photoShoot);
            }

            return RedirectToAction("Manage", "PhotoShoot");
        }
    }
}

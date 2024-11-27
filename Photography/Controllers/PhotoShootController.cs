using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
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
                return RedirectToAction("Gallery", "Gallery");
            }

            if (!this.ModelState.IsValid)
            {
             return this.View(model);
            }


            bool result = await this.photoShootService.AddPhotoShootAsync(model);

            if (result == false)
            {
                this.ModelState.AddModelError(nameof(model.CreatedAt), string.Format($"Датата на създаване трябва да бъде във формат: {0}, EntityDateFormat"));

                return this.View(model);
            }
            await photoShootService.AddPhotoShootAsync(model);

            return RedirectToAction(nameof(All));
        }

        //public async Task<IActionResult> Manage()
        //{
        //}

        //public async Task<IActionResult> DeclareParticipation()
        //{
        //}
    }
}

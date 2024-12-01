using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.PhotoShoot;
using Photography.Extensions;

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


            var userId = GetUserId();

            var photographer = await photoShootService.GetPhotographerByUserIdAsync(userId);

            if (photographer == null)
            {
                return Unauthorized(); 
            }

            var model = new AddPhotoShootViewModel
            {
                PhotographerId = photographer.Id.ToString()
            };

            return this.View(model);
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

            var userId = GetUserId();
            var photoShoots = await photoShootService.GetAllPhotoShootsForManageAsync(userId);

            return View(photoShoots);
        }



        [HttpGet]
        [MustBePhotographer]
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

            string? currentUserId = GetUserId();

            var userId = GetUserId();

            var photographer = await photoShootService.GetPhotographerByUserIdAsync(userId);

            if (photographer == null)
            {
                return Unauthorized();
            }

            string photographerId = photographer.Id.ToString();

            Guid userIdGuid;
            if (!Guid.TryParse(photographerId, out userIdGuid))
            {
                return Unauthorized();
            }

            var model = await photoShootService.GetPhotoShootToEditAsync(id, photographerId);

            return View(model);
        }

        [HttpPost]
        [MustBePhotographer]
        public async Task<IActionResult> Edit(EditPhotoShootViewModel model)
        {
            //bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return RedirectToAction("All", "PhotoShoot");
            //}

            var result = await photoShootService.EditPhotoShootAsync(model);

            if (!result)
            {
                Guid photoShootGuid = Guid.Empty;
                if (!photoShootService.IsGuidValid(model.Id, ref photoShootGuid))
                {
                    return RedirectToAction("All", "PhotoShoot");
                }

                string? currentUserId = GetUserId();

                var photographer = await photoShootService.GetPhotographerByUserIdAsync(currentUserId);

                if (photographer == null)
                {
                    return Unauthorized();
                }

                string photographerId = photographer.Id.ToString();

                Guid userIdGuid;
                if (!Guid.TryParse(currentUserId, out userIdGuid))
                {
                    return Unauthorized();
                }

                var photoShoot = await photoShootService.GetPhotoShootToEditAsync(model.Id, photographerId);

                return View(photoShoot);
            }

            return RedirectToAction("Manage", "PhotoShoot");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await photoShootService.GetPhotoShootDelete(id);

            if (model == null)
            {
                return RedirectToAction("Manage", "PhotoShoot");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePhotoShootViewModel model)
        {
            bool isPhotographer = await photoShootService.IsUserPhotographerAsync(GetUserId());

            if (!(User.IsAdmin() || isPhotographer))
            {
                return Unauthorized();
            }
            
          bool isDeleted= await photoShootService.DeletePhotoShootAsync(model.Id);

          if (!isDeleted)
          {
              return BadRequest();
          }

            return RedirectToAction("Manage", "PhotoShoot");
        }


        [HttpPost]
        public async Task<IActionResult> DeclareParticipation(string id)
        {
            Guid photoShootIdGuid;
            if (!Guid.TryParse(id, out photoShootIdGuid))
            {
                return BadRequest();
            }

            string? currentUserId = GetUserId();

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

            var result = await photoShootService.AddParticipantToPhotoShoot(photoShootIdGuid, userIdGuid);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> UserPhotoShoots()
        {
            string userId = GetUserId() ?? String.Empty;

            var model = await photoShootService.GetUserPhotoShootsAsync(userId);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeclineParticipation(string id)
        {
            string userId = GetUserId() ?? String.Empty;

            await photoShootService.RemoveUserFromParticipation(userId, id);

            return RedirectToAction(nameof(UserPhotoShoots));
        }

    }
}

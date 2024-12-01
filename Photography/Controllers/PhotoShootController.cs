﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.Photo;
using Photography.Core.ViewModels.PhotoShoot;
using Photography.Extensions;
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
            model.PhotographerId = GetUserId();
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

            var photoShoots = await photoShootService.GetAllPhotoShootsForManageAsync();

            return View(photoShoots);
        }

        [HttpPost]
        public async Task<IActionResult> DeclareParticipation(string id)
        {
            Guid photoShootIdGuid;
            if (!Guid.TryParse(id, out photoShootIdGuid))
            {

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

            await photoShootService.AddParticipantToPhotoShoot(photoShootIdGuid, userIdGuid);

            return RedirectToAction(nameof(All));
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

            Guid userIdGuid;
            if (!Guid.TryParse(currentUserId, out userIdGuid))
            {
                return Unauthorized();
            }

            var model = await photoShootService.GetPhotoShootToEditAsync(photoShootGuid, userIdGuid);

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

                Guid userIdGuid;
                if (!Guid.TryParse(currentUserId, out userIdGuid))
                {
                    return Unauthorized();
                }

                var photoShoot = await photoShootService.GetPhotoShootToEditAsync(photoShootGuid, userIdGuid);

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

            var photoShootToDelete = await photoShootService.DeletePhotoShootAsync(model.Id);
            return RedirectToAction("Manage", "PhotoShoot");
        }
    }
}

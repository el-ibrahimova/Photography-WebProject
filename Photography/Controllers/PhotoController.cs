using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using static Photography.Common.ApplicationConstants;

namespace Photography.Controllers
{
    [Authorize]
    public class PhotoController : BaseController
    {
        private readonly IPhotoService photoService;


        public PhotoController( IPhotoService _photoService)
        {
            photoService = _photoService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await photoService.GetAddPhotoAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await photoService.GetAddPhotoAsync();
                return View(model);
            }

            var userId = GetUserId() ?? String.Empty;

            await photoService.AddPhotoAsync(model, userId);

            return RedirectToAction("Gallery", "Gallery");
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseRating(string id)
        {
            var currentUserId = GetUserId();

            Guid photoIdGuid;
            if (!Guid.TryParse(id, out photoIdGuid))
            {
                return BadRequest("Невалидно ID на снимка.");
            }

            Guid userIdGuid;
            if (!Guid.TryParse(currentUserId, out userIdGuid))
            {
                return Unauthorized("Трябва да сте влезли в профила си.");
            }

            await photoService.IncreaseRatingAsync(photoIdGuid, userIdGuid);

            return RedirectToAction("Gallery", "Gallery");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid photoGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref photoGuid);
            if (!isGuidValid)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            var model = await photoService.GetPhotoDetailsAsync(photoGuid);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Favorite()
        {
            string userId = GetUserId() ?? String.Empty;

            var model = await photoService.GetFavoritePhotosAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(string id)
        {
            string? userId = GetUserId();

            Guid photoIdGuid = Guid.Empty;
            bool isPhotoGuidValid = this.IsGuidValid(id, ref photoIdGuid);
            if (!isPhotoGuidValid)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            Guid userIdGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(userId, ref userIdGuid);
            if (!isGuidValid)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            await photoService.AddPhotoToFavoritesAsync(userIdGuid, photoIdGuid);

            return RedirectToAction(nameof(Favorite));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(string id)
        {
            string userId = GetUserId() ?? String.Empty;

            await photoService.RemovePhotoFromFavoritesAsync(userId, id);

            return RedirectToAction(nameof(Favorite));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Guid photoGuid = Guid.Empty;
            if (!photoService.IsGuidValid(id, ref photoGuid))
            {
                return RedirectToAction("Gallery", "Gallery");
            }
            
            var model = await photoService.GetPhotoToEditAsync(photoGuid);
            if (model == null)
            {
                return BadRequest();
            }

            string userId = GetUserId() ?? String.Empty;

            Guid userIdGuid = Guid.Empty;
            if (!photoService.IsGuidValid(userId, ref userIdGuid) || model.UserOwnerId != userIdGuid)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPhotoViewModel model)
        {
            var result = await photoService.EditPhotoAsync(model);

            if (!result)
            {
                model.Categories = await photoService.GetCategoriesAsync();
                model.UserPhotoOwners = await photoService.GetAllUsersAsync();

                var photo = await photoService.GetPhotoByIdAsync(model.Id);
                model.SelectedCategoryIds = photo.PhotosCategories.Select(p => p.CategoryId).ToList();

                return View(model);
            }
            
            return RedirectToAction(nameof(Details), new { model.Id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await photoService.GetPhotoDelete(id);

            if (model == null)
            {
                return RedirectToAction("MyGallery", "Gallery");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
           var photoToDelete = await photoService.DeletePhotoAsync(model.Id);
            return RedirectToAction("MyGallery", "Gallery");
        }      
    }
}

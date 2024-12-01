using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photo;
using Photography.Extensions;
using static Photography.Common.ApplicationConstants;

namespace Photography.Controllers
{
    public class PhotoController : BaseController
    {
        private readonly IPhotoService photoService;


        public PhotoController(IPhotoService _photoService)
        {
            photoService = _photoService;
        }

        [HttpGet]
        [MustBePhotographer]
        public async Task<IActionResult> Add()
        {
            //bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return Unauthorized();
            //}

            var model = await photoService.GetAddPhotoAsync();
            return View(model);
        }

        [HttpPost]
        [MustBePhotographer]
        public async Task<IActionResult> Add(AddPhotoViewModel model)
        {
            //bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            //if (isPhotographer == false)
            //{
            //    return Unauthorized();
            //}

            var userId = GetUserId() ?? String.Empty;

            if (!model.IsPrivate)
            {
                model.UserOwnerId = Guid.Parse(userId);
            }

            if (!ModelState.IsValid)
            {
                model = await photoService.GetAddPhotoAsync();
                return View(model);
            }

            bool result = await photoService.AddPhotoAsync(model, userId);

            if (result == false)
            {
                return this.View(model);
            }

            return RedirectToAction("Gallery", "Gallery");
        }


        [HttpPost]
        public async Task<IActionResult> IncreaseRating(string id)
        {
            var currentUserId = GetUserId();

            Guid photoIdGuid;
            if (!Guid.TryParse(id, out photoIdGuid))
            {
                return BadRequest();
            }

            Guid userIdGuid;
            if (!Guid.TryParse(currentUserId, out userIdGuid))
            {
                return Unauthorized();
            }

            bool hasUserRated = await photoService.HasUserRatedAsync(photoIdGuid, userIdGuid);

            if (hasUserRated)
            {
                TempData["HasVoted"] = true;
                return RedirectToAction("Gallery", "Gallery");
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
            //bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return RedirectToAction("Gallery", "Gallery");
            //}

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
            if (!photoService.IsGuidValid(userId, ref userIdGuid) || model.UserOwnerId != userIdGuid.ToString())
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPhotoViewModel model)
        {
            //bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            //if (!isPhotographer)
            //{
            //    return RedirectToAction("Gallery", "Gallery");
            //}

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
        public async Task<IActionResult> Manage()
        {
            //bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            //if (!User.IsInRole(AdminRoleName) && !isPhotographer)
            //{
            //    return Unauthorized();
            //}

            var photos = await photoService.GetAllPhotosAsync();

            return View(photos);
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
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            if (!(User.IsAdmin() || isPhotographer))
            {
                return RedirectToAction("Manage", "Photo");
            }

            var photoToDelete = await photoService.DeletePhotoAsync(model.Id);

            return RedirectToAction("MyGallery", "Gallery");
        }
    }
}

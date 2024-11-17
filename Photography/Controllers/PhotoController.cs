using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photo;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isPhotographer =  photoService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            var model = await photoService.GetAddPhotoAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotoViewModel model)
        {
            bool isPhotographer = photoService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

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
            bool isPhotographer = photoService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

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
            bool isPhotographer = photoService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

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

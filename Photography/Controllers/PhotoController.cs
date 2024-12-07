using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photo;
using Photography.Extensions;
namespace Photography.Controllers
{
    public class PhotoController : BaseController
    {
        private readonly IPhotoService photoService;


        public PhotoController(IPhotoService _photoService)
        {
            photoService = _photoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Gallery(GalleryWithSearchFilterViewModel inputModel)
        {
            ICollection<GalleryViewModel> gallery = await this.photoService.GetGalleryAsync(inputModel);

            var viewModel = new GalleryWithSearchFilterViewModel();


            viewModel.Gallery = gallery;
            viewModel.AllCategories = (await photoService.GetCategoriesAsync())
                .Select(c => c.Name) 
                .ToList();


            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> MyGallery()
        {
            var userIdString = GetUserId();

            Guid userIdGuid=Guid.Empty;
            if (!IsGuidValid(userIdString, ref userIdGuid))
            {
                return Unauthorized();
            }

            var model = await photoService.GetPrivateGalleryAsync(userIdGuid);

            return View(model);
        }

        [HttpGet]
        [MustBePhotographer]
        public async Task<IActionResult> Add()
        {
            var model = await photoService.GetAddPhotoAsync();
            return View(model);
        }

        [HttpPost]
        [MustBePhotographer]
        public async Task<IActionResult> Add(AddPhotoViewModel model)
        {
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

            return RedirectToAction(nameof(Manage));
        }


        [HttpPost]
        public async Task<IActionResult> IncreaseRating(string id)
        {
            var currentUserId = GetUserId();

            Guid photoIdGuid=Guid.Empty;
            if (!IsGuidValid(id, ref photoIdGuid))
            {
                return BadRequest();
            }

            Guid userIdGuid=Guid.Empty;
            if (!IsGuidValid(currentUserId, ref userIdGuid))
            {
                return Unauthorized();
            }

            bool hasUserRated = await photoService.HasUserRatedAsync(photoIdGuid, userIdGuid);

            if (hasUserRated)
            {
                TempData["HasVoted"] = true;
                return RedirectToAction(nameof(Gallery));
            }

            await photoService.IncreaseRatingAsync(photoIdGuid, userIdGuid);

            return RedirectToAction(nameof(Gallery));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid photoGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoGuid))
            {
                return RedirectToAction("Gallery", "Photo");
            }

            DetailsViewModel? model = await photoService.GetPhotoDetailsAsync(photoGuid);

            if (model == null)
            {
                return RedirectToAction(nameof(Gallery));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Favorite()
        {
            string userId = GetUserId() ?? String.Empty;

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return RedirectToAction(nameof(Gallery));
            }

            ICollection<FavoriteViewModel> model = await photoService.GetFavoritePhotosAsync(userIdGuid);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(string id)
        {
            string? userId = GetUserId();

            Guid photoIdGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoIdGuid))
            {
                return RedirectToAction(nameof(Gallery));
            }

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return RedirectToAction(nameof(Gallery));
            }

           bool isAdded= await photoService.AddPhotoToFavoritesAsync(userIdGuid, photoIdGuid);

           if (!isAdded)
           {
             //  TempData["ErrorMessage"] = "Възникна неочаквана грешка. Снимктата не беше добавена в любими.";
                return RedirectToAction(nameof(Gallery));
           }

           return RedirectToAction(nameof(Favorite));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(string id)
        {
            string userId = GetUserId() ?? String.Empty;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return RedirectToAction(nameof(Gallery));
            }

            bool isRemoved = await photoService.RemovePhotoFromFavoritesAsync(userId, id);

            if (!isRemoved)
            {
                //  TempData["ErrorMessage"] = "Възникна неочаквана грешка. Снимктата не беше премахната от любими.";
                return RedirectToAction(nameof(Favorite));
            }

            return RedirectToAction(nameof(Favorite));
        }

        [HttpGet]
        [MustBePhotographer]
        public async Task<IActionResult> Edit(string id)
        {
            Guid photoGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoGuid))
            {
                return RedirectToAction(nameof(Gallery));
            }

            var model = await photoService.GetPhotoToEditAsync(photoGuid);
            if (model == null)
            {
                return BadRequest();
            }

            string userId = GetUserId() ?? String.Empty;

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid) || model.UserOwnerId != userIdGuid.ToString())
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        [MustBePhotographer]
        public async Task<IActionResult> Edit(EditPhotoViewModel model)
        {
            
            bool result = await photoService.EditPhotoAsync(model);

            Guid photoIdGuid = Guid.Parse(model.Id);

            if (!result)
            {
                model.Categories = await photoService.GetCategoriesAsync();
                model.UserPhotoOwners = await photoService.GetAllUsersAsync();

                var photo = await photoService.GetPhotoByIdAsync(photoIdGuid);
                model.SelectedCategoryIds = photo.PhotosCategories.Select(p => p.CategoryId).ToList();

                return View(model);
            }

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            if (!User.IsAdmin() && !isPhotographer)
            {
                return Unauthorized();
            }

            ICollection<AllPhotosViewModel> photos = await photoService.GetAllPhotosAsync();

            return View(photos);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            if (!User.IsAdmin()&& !isPhotographer)
            {
                return Unauthorized();
            }

            Guid photoGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoGuid))
            {
                return NotFound();
            }

            DeleteViewModel? model = await photoService.GetPhotoDelete(photoGuid);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

            if (!(User.IsAdmin() || isPhotographer))
            {
                return Unauthorized();
            }

            bool isDeleted  = await photoService.DeletePhotoAsync(model.Id);

            if (!isDeleted)
            {
                //  TempData["ErrorMessage"] = "Възникна неочаквана грешка. Снимктата не беше изтрита.";
                return RedirectToAction(nameof(Manage));
            }

            return RedirectToAction(nameof(Manage));
        }
    }
}

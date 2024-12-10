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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Gallery(GalleryWithSearchFilterViewModel inputModel)
        {
            ICollection<GalleryViewModel> gallery = await photoService.GetGalleryAsync(inputModel);

            int allPhotosCount = await this.photoService.GetPhotosCountByFilterAsync(inputModel);

            GalleryWithSearchFilterViewModel viewModel = new()
            {
                Gallery = gallery,
                AllCategories = (await photoService.GetCategoriesAsync()).Select(c => c.Name)
                .ToList(),
                SearchQuery = inputModel.SearchQuery,
                CategoryFilter = inputModel.CategoryFilter,
                DateFilter = inputModel.DateFilter,
                CurrentPage = inputModel.CurrentPage,
                TotalPages = (int)Math.Ceiling(((double)allPhotosCount / inputModel.EntitiesPerPage!.Value))
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> MyGallery(GalleryWithSearchFilterViewModel inputModel)
        {
            var userIdString = GetUserId();

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userIdString, ref userIdGuid))
            {
                return Unauthorized();
            }

            ICollection<GalleryViewModel> myGallery = await photoService.GetPrivateGalleryAsync(inputModel, userIdGuid);

            int allPhotosCount = await photoService.GetPrivatePhotosCountByFilterAsync(inputModel, userIdGuid);

            GalleryWithSearchFilterViewModel viewModel = new()
            {
                Gallery = myGallery,
                AllCategories = (await photoService.GetCategoriesAsync()).Select(c => c.Name)
                    .ToList(),
                SearchQuery = inputModel.SearchQuery,
                CategoryFilter = inputModel.CategoryFilter,
                DateFilter = inputModel.DateFilter,
                CurrentPage = inputModel.CurrentPage,
                TotalPages = (int)Math.Ceiling(((double)allPhotosCount / inputModel.EntitiesPerPage!.Value))
            };

            return View(viewModel);
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
            var userId = GetUserId();

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return Unauthorized();
            }

          if (!ModelState.IsValid)
            {
                model = await photoService.GetAddPhotoAsync();
                return View(model);
            }

            bool result = await photoService.AddPhotoAsync(model, userId);

            if (result == false)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Manage));
        }


        [HttpPost]
        public async Task<IActionResult> IncreaseRating(string id)
        {
            var currentUserId = GetUserId();

            Guid photoIdGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoIdGuid))
            {
                return NotFound();
            }

            Guid userIdGuid = Guid.Empty;
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
                return NotFound();
            }
            
            DetailsViewModel? model = await photoService.GetPhotoDetailsAsync(photoGuid);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Favorite()
        {
            string userId = GetUserId();

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return Unauthorized();
            }

            ICollection<FavoriteViewModel> model = await photoService.GetFavoritePhotosAsync(userIdGuid);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(string id)
        {
            string userId = GetUserId();

            Guid photoIdGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoIdGuid))
            {
                return NotFound();
            }

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid))
            {
                return Unauthorized();
            }

            bool isAdded = await photoService.AddPhotoToFavoritesAsync(userIdGuid, photoIdGuid);

            if (!isAdded)
            {
                return RedirectToAction(nameof(Gallery));
            }

            return RedirectToAction(nameof(Favorite));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(string id)
        {
            string userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return RedirectToAction(nameof(Gallery));
            }

            bool isRemoved = await photoService.RemovePhotoFromFavoritesAsync(userId, id);

            if (!isRemoved)
            {
                return RedirectToAction(nameof(Favorite));
            }

            return RedirectToAction(nameof(Favorite));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoService.IsPhotoOwnedByPhotographerAsync(id, GetUserId());

            if ((!isPhotographer && !User.IsAdmin()) && !isOwner)
            {
                return Unauthorized();
            }

            Guid photoGuid = Guid.Empty;
            if (!IsGuidValid(id, ref photoGuid))
            {
                return RedirectToAction(nameof(Gallery));
            } 

            var model = await photoService.GetPhotoToEditAsync(photoGuid);
            if (model == null)
            {
                return NotFound();
            }

            string userId = GetUserId() ?? String.Empty;

            Guid userIdGuid = Guid.Empty;
            if (!IsGuidValid(userId, ref userIdGuid) && model.UserPhotographerId != userIdGuid.ToString())
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPhotoViewModel model)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoService.IsPhotoOwnedByPhotographerAsync(model.Id, GetUserId());

            if ((!isPhotographer && !User.IsAdmin()) && !isOwner)
            {
                return Unauthorized();
            }

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
        public async Task<IActionResult> Manage(ManageWithSearchFilterViewModel model)
        {
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());

          
            if (!User.IsAdmin() && !isPhotographer)
            {
                return Unauthorized();
            }

            ICollection<AllPhotosViewModel> photos = await photoService.GetAllPhotosAsync(model);

            int allPhotosCount = await this.photoService.GetManagePhotosCountByFilterAsync(model);

            ManageWithSearchFilterViewModel viewModel = new()
            {
                AllPhotos = photos,
                AllCategories = (await photoService.GetCategoriesAsync()).Select(c => c.Name)
                    .ToList(),
                SearchQuery = model.SearchQuery,
                CategoryFilter = model.CategoryFilter,
                DateFilter = model.DateFilter,
                CurrentPage = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(((double)allPhotosCount / model.EntitiesPerPage!.Value))
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        { 
            bool isPhotographer = await photoService.IsUserPhotographerAsync(GetUserId());
            bool isOwner = await photoService.IsPhotoOwnedByPhotographerAsync(id, GetUserId());

            if ((!isPhotographer && !User.IsAdmin()) && !isOwner)
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
            bool isOwner = await photoService.IsPhotoOwnedByPhotographerAsync(model.Id, GetUserId());

            if ((!isPhotographer && !User.IsAdmin()) && !isOwner)
            {
                return Unauthorized();
            }

            bool isDeleted = await photoService.DeletePhotoAsync(model.Id);

            if (!isDeleted)
            {
                return RedirectToAction(nameof(Manage));
            }

            return RedirectToAction(nameof(Manage));
        }
    }
}

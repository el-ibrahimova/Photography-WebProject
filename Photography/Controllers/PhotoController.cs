using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using System.Security.Claims;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Gallery;
using static Photography.Common.ApplicationConstants;

namespace Photography.Controllers
{
    [Authorize]
    public class PhotoController : BaseController
    {
        private readonly PhotographyDbContext context;
        private readonly IPhotoService photoService;


        public PhotoController(PhotographyDbContext data, IPhotoService _photoService)
        {
            context = data;
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
            Guid photoIdGuid;
            if (!Guid.TryParse(id, out photoIdGuid))
            {
                return BadRequest("Невалидно ID на снимка.");
            }

            var currentUserId = GetUserId();
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
                return this.RedirectToAction("Gallery", "Gallery");
            }

            var model = await photoService.GetPhotoDetailsAsync(photoGuid);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Favorite()
        {
            var model = await context.FavoritePhotos
                .AsNoTracking()
                .Where(fp => fp.UserId.ToString() == GetUserId() && fp.Photo.IsDeleted == false)
                .Select(fp => new FavoriteViewModel()
                {
                    Id = fp.Photo.Id.ToString(),
                    ImageUrl = fp.Photo.ImageUrl,
                    Title = fp.Photo.Title,
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(string id)
        {
            Guid photoIdGuid = Guid.Empty;

            bool isPhotoGuidValid = this.IsGuidValid(id, ref photoIdGuid);
            if (!isPhotoGuidValid)
            {
                // invalid id format
                return this.RedirectToAction("MyGallery", "Gallery");
            }

            var photo = await context.Photos
                .Where(p => p.IsDeleted == false && p.Id == photoIdGuid)
                .Include(fp => fp.FavoritePhotos)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return BadRequest();
            }

            string? userId = GetUserId();
            Guid userIdGuid = Guid.Empty;

            bool isGuidValid = this.IsGuidValid(userId, ref userIdGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction("MyGallery", "Gallery");
            }

            if (!context.FavoritePhotos.Any(fp => fp.UserId == userIdGuid && fp.PhotoId == photoIdGuid))
            {
                photo.FavoritePhotos.Add(new FavoritePhoto()
                {
                    UserId = userIdGuid,
                    PhotoId = photoIdGuid
                });

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Favorite));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(string id)
        {
            var photo = await context.Photos
                .Where(p => !p.IsDeleted && p.Id.ToString() == id)
                .Include(p => p.FavoritePhotos)
                .FirstOrDefaultAsync();

            var user = await context.FavoritePhotos
                .Where(u => u.UserId.ToString() == GetUserId())
                .FirstOrDefaultAsync();

            if (photo == null || user == null)
            {
                return BadRequest();
            }

            context.FavoritePhotos.Remove(user);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Favorite));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Guid photoIdGuid = Guid.Empty;

            bool isPhotoGuidValid = this.IsGuidValid(id, ref photoIdGuid);
            if (!isPhotoGuidValid)
            {
                return this.RedirectToAction("Gallery", "Gallery");
            }

            var photo = await context.Photos
                .Where(p => p.IsDeleted == false && p.Id == photoIdGuid)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();
            Guid userIdGuid = Guid.Empty;

            bool isUserIdGuidValid = this.IsGuidValid(userId, ref userIdGuid);
            if (!isUserIdGuidValid)
            {
                return this.RedirectToAction("Gallery", "Gallery");
            }

            if (photo.UserOwnerId != userIdGuid)
            {
                return Unauthorized();
            }

            var model = new EditPhotoViewModel()
            {
                Title = photo.Title,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                ImageUrl = photo.ImageUrl,
                IsPrivate = photo.IsPrivate,
                UserOwnerId = photo.UserOwnerId,

            };

            model.Categories = await GetCategories();
            model.UserPhotoOwners = await GetAllUsers();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPhotoViewModel model)
        {

            Guid photoIdGuid = Guid.Empty;

            bool isPhotoGuidValid = this.IsGuidValid(model.Id.ToString(), ref photoIdGuid);
            if (!isPhotoGuidValid)
            {
                return this.RedirectToAction("Gallery", "Gallery");
            }

            var photo = await context.Photos
                .Include(p => p.PhotosCategories) // 
                .Where(p => p.IsDeleted == false && p.Id == photoIdGuid)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();
            Guid userIdGuid = Guid.Empty;

            bool isUserIdGuidValid = this.IsGuidValid(userId, ref userIdGuid);
            if (!isUserIdGuidValid)
            {
                return this.RedirectToAction("Gallery", "Gallery");
            }

            if (photo.UserOwnerId != userIdGuid)
            {
                return Unauthorized();
            }

            DateTime uploadedAt;
            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out uploadedAt))
            {
                ModelState.AddModelError(nameof(model.UploadedAt), $"Невалидна дата! Датата трябва да бъде във формат: {EntityDateFormat}");

                model.Categories = await GetCategories();
                model.UserPhotoOwners = await GetAllUsers();
                model.SelectedCategoryIds = photo.PhotosCategories.Select(pc => pc.CategoryId).ToList();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                model.UserPhotoOwners = await GetAllUsers();
                model.SelectedCategoryIds = photo.PhotosCategories.Select(pc => pc.CategoryId).ToList();
                return View(model);
            }

            photo.Title = model.Title;
            photo.ImageUrl = model.ImageUrl;
            photo.Description = model.Description;
            photo.IsPrivate = model.IsPrivate;
            photo.UserOwnerId = model.UserOwnerId;
            photo.UploadedAt = DateTime.Now;
            photo.PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory() { CategoryId = id })
                .ToList();

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { model.Id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            Guid photoGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref photoGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction("MyGallery", "Gallery");
            }

            var model = await context.Photos
                .AsNoTracking()
                .Where(p => p.IsDeleted == false && p.Id == photoGuid)
                .Select(p => new DeleteViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    UploadedAt = p.UploadedAt.ToString(EntityDateFormat),
                    DeletedAt = null,
                    UserOwnerId = p.UserOwnerId.ToString(),
                    Owner = p.Owner.UserName
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            var photo = await context.Photos
                .Where(p => p.IsDeleted == false && p.Id.ToString() == model.Id)
                .FirstOrDefaultAsync();

            if (photo != null)
            {
                photo.IsDeleted = true;
                photo.DeletedAt = DateTime.Now;

                await context.SaveChangesAsync();
            }

            return RedirectToAction("MyGallery", "Gallery");
        }

        private async Task<ICollection<CategoryViewModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name
                })
                .ToListAsync();
        }


        public async Task<ICollection<UserViewModel>> GetAllUsers()
        {
            return await context.Users
                .AsNoTracking()
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    UserName = u.UserName ?? String.Empty
                }).ToListAsync();
        }
    }
}

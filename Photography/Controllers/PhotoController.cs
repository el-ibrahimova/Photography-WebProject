using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using System.Security.Claims;
using Photography.Core.Interfaces;
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
            photoService= _photoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Gallery()
        {
            var photos = await photoService.GetGalleryAsync();

            return View(photos);
        }


        [HttpGet]
        public async Task<IActionResult> MyGallery()
        {
            var userIdString = GetUserId();

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userIdGuid))
            {
                return Unauthorized();
            }

            var model = await context.Photos
                .AsNoTracking()
                .Where(p => !p.IsPrivate || p.UserOwnerId == userIdGuid && p.IsDeleted == false)
                .Select(p => new MyGalleryViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    UserOwnerId = userIdGuid.ToString()
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPhotoViewModel();
            model.Categories = await GetCategories();
            model.UserPhotoOwners = await GetAllUsers();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotoViewModel model)
        {
            DateTime uploadedAt;

            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out uploadedAt))
            {
                ModelState.AddModelError(nameof(model.UploadedAt),
                    $"Невалиден формат за дата. Датата трябва да бъде във формат: {EntityDateFormat}");

                model.Categories = await GetCategories();
                model.UserPhotoOwners = await GetAllUsers();
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();
                model.UserPhotoOwners = await GetAllUsers();
                return View(model);
            }

           var validCategories = await context
               .Categories.Select(c => c.Id).ToListAsync();

            foreach (var categoryId in model.SelectedCategoryIds)
            {
                if (!validCategories.Contains(categoryId))
                {
                    ModelState.AddModelError(nameof(model.SelectedCategoryIds), $"Категория с ID {categoryId} не съществува.");
                    model.Categories = await GetCategories();
                    return View(model);
                }
            }

            var userId = GetUserId();

            if (model.IsPrivate && string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var userOwnerId = model.UserOwnerId;

            var photo = new Photo
            {
                Title = model.Title,
                Description = model.Description,
                UploadedAt = uploadedAt,
                ImageUrl = model.ImageUrl,
                IsPrivate = model.IsPrivate,
                UserOwnerId =
                    model.IsPrivate
                        ? userOwnerId
                        : Guid.Parse(userId), //  save userOwnerId only if photo is private, or else save it to userId
                PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory() { CategoryId = id})
                    .ToList()
            };

            await context.Photos.AddAsync(photo);
            await context.SaveChangesAsync();

            return RedirectToAction("Gallery");
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseRating(string id)
        {
            Guid photoId;
            if (!Guid.TryParse(id, out photoId))
            {
                return BadRequest("Невалидно ID на снимка.");
            }

            var photo = await context
                .Photos.Where(p => p.Id == photoId && p.IsDeleted==false)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return NotFound("Снимката не е намерена.");
            }

            var currentUserId = GetUserId();
            Guid userIdGuid;
            if (!Guid.TryParse(currentUserId, out userIdGuid))
            {
                return Unauthorized("Трябва да сте влезли в профила си.");
            }

            bool hasUserRated = await context
                .PhotosRatings.AnyAsync(r => r.PhotoId == photoId && r.UserId == userIdGuid);

            if (!hasUserRated)
            {
                photo.Rating += 1;

                var photoRating = new PhotoRating
                {
                    PhotoId = photoId,
                    UserId = userIdGuid
                };
                context.PhotosRatings.Add(photoRating);

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Gallery));
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid photoGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref photoGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Gallery));
            }

            var photo = await context.Photos
                .Include(p => p.Owner)
                .Include(p => p.PhotosCategories)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == photoGuid);

            if (photo == null || photo.IsDeleted == true)
            {
                return BadRequest();
            }

            var model = new DetailsViewModel()
            {
                Id = photo.Id.ToString(),
                Title = photo.Title,
                ImageUrl = photo.ImageUrl,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                IsFavorite = photo.IsFavorite,
                IsPrivate = photo.IsPrivate,
                IsDeleted = photo.IsDeleted,
                Rating = photo.Rating,
                UserOwnerId = photo.UserOwnerId,
                Categories = photo.PhotosCategories.Select(p => p.Category.Name).ToList(),
                Owner = photo.Owner,
            };

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
                return this.RedirectToAction(nameof(MyGallery));
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
                return this.RedirectToAction(nameof(MyGallery));
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
                return this.RedirectToAction(nameof(Gallery));
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
                return this.RedirectToAction(nameof(Gallery));
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
                return this.RedirectToAction(nameof(Gallery));
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
                return this.RedirectToAction(nameof(Gallery));
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
            photo.PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory() { CategoryId = id})
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
                return this.RedirectToAction(nameof(MyGallery));
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

            return RedirectToAction(nameof(MyGallery));
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

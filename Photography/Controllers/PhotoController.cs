using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Claims;
using static Photography.Common.ApplicationConstants;

namespace Photography.Controllers
{
    [Authorize]
    public class PhotoController : BaseController
    {
        private readonly PhotographyDbContext context;


        public PhotoController(PhotographyDbContext data)
        {
            context = data;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Gallery()
        {
            var model = await context.Photos
               .AsNoTracking()
               .Where(p => !p.IsPrivate || p.IsDeleted == false)
               .Select(p => new GalleryViewModel()
               {
                   Id = p.Id.ToString(),
                   Title = p.Title,
                   ImageUrl = p.ImageUrl,
                   IsPrivate = p.IsPrivate,
               })
               .ToListAsync();

            return View(model);
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

            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out uploadedAt))
            {
                ModelState.AddModelError(nameof(model.UploadedAt), $"Невалиден формат за дата. Датата трябва да бъде във формат: {EntityDateFormat}");

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

            // Проверка на валидност на категориите
            //var validCategories = await context.Categories.Select(c => c.Id).ToListAsync();
            //foreach (var categoryId in model.SelectedCategoryIds)
            //{
            //    if (!validCategories.Contains(categoryId))
            //    {
            //        ModelState.AddModelError(nameof(model.SelectedCategoryIds), $"Категория с ID {categoryId} не съществува.");
            //        model.Categories = await GetCategories();
            //        return View(model);
            //    }
            //}

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
                UserOwnerId = model.IsPrivate ? userOwnerId : Guid.Parse(userId), //  save userOwnerId only if photo is private, or else save it to userId
                PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory() { CategoryId = id }).ToList()
            };

            await context.Photos.AddAsync(photo);
            await context.SaveChangesAsync();

            return RedirectToAction("Gallery");
        }

        //[HttpPost]
        //public async Task<IActionResult> RatePhoto(Guid photoId, int rating)
        //{
        //    var userIdString = GetUserId(); // Get the current user's ID

        //  if (!Guid.TryParse(userIdString, out var userIdGuid))
        //    {
        //        return BadRequest("Невалидно потребителско ID.");
        //    }

        //    // Check if the user exists in the User table
        //    var userExists = await context.Users.AnyAsync(u => u.Id == userIdGuid);
        //    if (!userExists)
        //    {
        //        return NotFound("Потребителят не съществува."); 
        //    }

        //    // Check if the photo exists
        //    var photo = await context.Photos.FindAsync(photoId);
        //    if (photo == null || photo.IsDeleted==true)
        //    {
        //        return NotFound("Снимката не съществува."); 
        //    }

        //    // Check if the user already rated the photo
        //    var existingRating = await context.PhotosRatings
        //        .FirstOrDefaultAsync(r => r.PhotoId == photoId && r.UserId == userIdGuid);

        //    if (existingRating != null)
        //    {
        //        // If it exists, update the rating
        //        existingRating.Rate = rating;
        //    }
        //    else
        //    {
        //        // If it does not exist, create a new rating
        //        var newRating = new PhotoRating
        //        {
        //            PhotoId = photoId,
        //            UserId = userIdGuid,
        //            Rate = rating
        //        };
        //        await context.PhotosRatings.AddAsync(newRating);
        //    }

        //    var totalRatings = await context.PhotosRatings
        //        .Where(r => r.PhotoId == photoId)
        //        .AverageAsync(r => (double)r.Rate);

        //    photo.Rating = (int)Math.Round(totalRatings);

        //    await context.SaveChangesAsync();

        //    return RedirectToAction("Gallery");
        //}

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid photoGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref photoGuid);
            if (!isGuidValid)
            {
                // invalid id format
                return this.RedirectToAction(nameof(Gallery));
            }

            var photo = await context.Photos
                .Include(p => p.Owner)
                .Include(p => p.PhotosCategories)
                .ThenInclude(p=>p.Category)
                    .Where(p => p.IsDeleted == false).
                FirstOrDefaultAsync(p => p.Id == photoGuid);

            if (photo == null)
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
                Rating = photo.Rating,
                UserOwnerId = photo.UserOwnerId,
                Categories = photo.PhotosCategories.Select(p => p.Category.Name).ToList(),
                Owner = photo.Owner,
            };

            return View(model);
        }

        public async Task<IActionResult> AddToFavorite()
        {
            return View();
        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            Guid photoGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref photoGuid);
            if (!isGuidValid)
            {
                // invalid id format
                return this.RedirectToAction(nameof(Gallery));
            }

            var model = await context.Photos
                .AsNoTracking()
                .Where(p => p.IsDeleted == false && p.Id == photoGuid)
                .Select(p => new DeleteViewModel()
                {
                    Id=p.Id.ToString(),
                    Title = p.Title,
                    UploadedAt = p.UploadedAt.ToString(EntityDateFormat),
                    UserOwnerId = p.UserOwnerId.ToString(),
                    Owner = p.Owner.UserName 
                })
                .FirstOrDefaultAsync();

            return View(model);
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

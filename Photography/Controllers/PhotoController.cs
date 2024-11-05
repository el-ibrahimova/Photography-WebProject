using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using System.Security.Claims;
using static Photography.Common.ApplicationConstants;

namespace Photography.Controllers
{
    [Authorize]
    public class PhotoController : Controller
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
            var userIdString = GetUserId();

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userIdGuid))
            {
                return Unauthorized();
            }

            var model = await context.Photos
                .AsNoTracking()
                .Where(p => !p.IsPrivate || p.UserOwnerId == userIdGuid && p.IsDeleted==false)
                .Select(p => new GalleryPhotoViewModel()
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
                PhotosCategories = model.SelectedCategoryIds.Select(id=> new PhotoCategory(){CategoryId = id}).ToList()
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

        public async Task<IActionResult> Details()
        {
            return View();
        }

        public async Task<IActionResult> AddToFavorite()
        {
            return View();
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

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}

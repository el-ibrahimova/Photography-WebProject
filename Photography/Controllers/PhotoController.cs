using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using System.Security.Claims;
using Photography.Infrastructure.Data.Models;
using static Photography.Common.ApplicationConstants;
using Microsoft.VisualBasic;
using System.Globalization;

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
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid.TryParse(userIdString, out var userIdGuid);

            //if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userIdGuid))
            //{
            //    return Unauthorized();
            //}

            var model = await context.Photos
                .AsNoTracking()
                .Where(p => !p.IsPrivate || p.UserOwnerId == userIdGuid)
                .Select(p => new GalleryPhotoViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    UserOwnerId = userIdGuid
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
            var validCategories = await context.Categories.Select(c => c.Id).ToListAsync();
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
                Id=model.Id,
                Title = model.Title,
                Description = model.Description,
                UploadedAt = uploadedAt,
                ImageUrl = model.ImageUrl,
                IsPrivate = model.IsPrivate,
                UserOwnerId = model.IsPrivate ? userOwnerId : null, //  save userId only if photo is private
                PhotosCategories = model.SelectedCategoryIds.Select(id=> new PhotoCategory(){CategoryId = id}).ToList()
            };
          
            await context.Photos.AddAsync(photo);
            await context.SaveChangesAsync();

            return RedirectToAction("Gallery");
        }

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
                    Id = c.Id,
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
                    Id = Guid.Parse(u.Id),
                    UserName = u.UserName ?? String.Empty  
                }).ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}

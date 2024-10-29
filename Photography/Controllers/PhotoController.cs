using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using System.Security.Claims;

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

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userIdGuid))
            {
                return Unauthorized();
            }
            var model = await context.Photos
                .AsNoTracking()
                .Where(p => !p.IsPrivate || p.UserOwnerId==userIdGuid)
                .Select(p => new GalleryPhotoViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate

                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPhotoViewModel();
            model.Categories = await GetCategories();
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(AddPhotoViewModel)
      //{

            //if (ModelState.IsValid)
            //{
            //    var photo = new Photo
            //    {
            //        Title = model.Title,
            //        // Други свойства на снимката
            //    };

            //    // Добавете избраните категории
            //    foreach (var categoryId in model.SelectedCategoryIds)
            //    {
            //        photo.PhotoCategories.Add(new PhotoCategory { CategoryId = categoryId });
            //    }

            //    _context.Photos.Add(photo);
            //    await _context.SaveChangesAsync();

            //    return RedirectToAction("Gallery");
          //}

         // return View(model);



     // }

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

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}

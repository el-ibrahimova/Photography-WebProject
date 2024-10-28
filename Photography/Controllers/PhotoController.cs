using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotoViewModel)
        {

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

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}

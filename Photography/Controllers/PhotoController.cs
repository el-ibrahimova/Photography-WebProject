using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.ViewModels.Photo;
using Photography.Data;

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
            var model = await context.Photos
                .AsNoTracking()
                .Select(p => new GalleryPhotoViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,

                })
                .ToListAsync();

            return View();
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }

        public async Task<IActionResult> AddToFavorite()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Gallery;

namespace Photography.Controllers
{
    public class GalleryController : BaseController
    {

        private readonly IGalleryService galleryService;

        public GalleryController(IGalleryService _galleryService)
        {
            galleryService= _galleryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Gallery()
        {
            var model = await galleryService.GetGalleryAsync();

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

            var model = await galleryService.GetPrivateGalleryAsync(userIdGuid);
           
            return View(model);
        }
    }
}

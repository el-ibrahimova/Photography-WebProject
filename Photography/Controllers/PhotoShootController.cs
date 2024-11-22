using Microsoft.AspNetCore.Mvc;
using Photography.Core.Services;

namespace Photography.Controllers
{
    public class PhotoShootController : BaseController
    {
        private readonly PhotoShootService photoShootService;

        public PhotoShootController(PhotoShootService _photoShootService)
        {
            photoShootService = _photoShootService;
        }

        public IActionResult All()
        {
            return View();
        }
    }
}

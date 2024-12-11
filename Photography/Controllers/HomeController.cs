using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Photography.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error(int? statusCode = null)
        {
            if (!statusCode.HasValue)
            {
                return View();
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }
            else if (statusCode == 401 || statusCode == 403)
            {
                return View("Error403");
            }

            return View("Error500");
        }
    }
}

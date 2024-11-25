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

        public IActionResult Index()
        {
            //if (User?.Identity != null && User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Gallery", "Gallery");
            //}
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            if (!statusCode.HasValue)
            {
                return this.View();
            }

            if (statusCode == 404)
            {
                return this.View("Error404");
            }
            else if (statusCode == 401 || statusCode == 403)
            {
                return this.View("Error403");
            }

            return this.View("Error500");
        }
    }
}

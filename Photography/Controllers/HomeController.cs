using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Photography.Controllers
{
    using Photography.Core.ViewModels;
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
         
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User?.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Gallery", "Gallery");
            }
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photographer;
using Photography.Extensions;
using static Photography.Common.EntityValidationMessages;

namespace Photography.Controllers
{
    public class PhotographerController : BaseController
    {
        private readonly IPhotographerService photographerService;

        public PhotographerController(IPhotographerService _photographerService)
        {
            photographerService = _photographerService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPhotographerViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotographerViewModel model)
        {
            if (await photographerService.UserWithBrandNameExistAsync(model.BrandName))
            {
                ModelState.AddModelError(nameof(model.BrandName), BrandNameExist);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await photographerService.CreateAsync(User.GetUserId(), model.BrandName);

            return RedirectToAction("Gallery", "Gallery");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Controllers;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photographer;
using Photography.Extensions;
using static Photography.Common.ApplicationConstants;
using static Photography.Common.EntityValidationMessages;

namespace Photography.Areas.Admin.Controllers
{
    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
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

            bool result = await photographerService.CreateAsync(User.GetUserId()!, model.BrandName);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "UserManagement");
        }
    }
}

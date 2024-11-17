using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Category;

namespace Photography.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService=_categoryService;
        }
        public IActionResult Manage()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isPhotographer = await categoryService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            bool isPhotographer = await categoryService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await categoryService.AddCategoryAsync(model);

            return RedirectToAction(nameof(Manage));
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Remove()
        {
            return View();
        }
    }

}

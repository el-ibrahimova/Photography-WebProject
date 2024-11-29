using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Category;
using CategoryFormViewModel = Photography.Core.ViewModels.Category.CategoryFormViewModel;

namespace Photography.Controllers
{

    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            bool isPhotographer = await categoryService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            var categories = await categoryService.GetAllCategoriesAsync();

            return View(categories);
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isPhotographer = await categoryService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            Guid categoryGuid = Guid.Empty;
            if (!categoryService.IsGuidValid(id, ref categoryGuid))
            {
                return RedirectToAction("Manage", "Category");
            }

            var model = await categoryService.GetCategoryToEditAsync(id);
            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryFormViewModel model)
        {
            bool isPhotographer = await categoryService.IsUserPhotographerAsync(GetUserId());

            if (!isPhotographer)
            {
                return RedirectToAction("Gallery", "Gallery");
            }

            var result = await categoryService.EditCategoryAsync(model);

            if (!result)
            {
                return View(model);
            }

            return RedirectToAction("Manage", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await categoryService.GetCategoryDelete(id);

            if (model == null)
            {
                return RedirectToAction("Manage", "Category");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryFormViewModel model)
        {
            var categoryToDelete = await categoryService.DeleteCategoryAsync(model.Id);
            return RedirectToAction("Manage", "Category");
        }
    }
}

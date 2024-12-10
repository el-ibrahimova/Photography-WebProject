using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photography.Attributes;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Category;
using static Photography.Common.ApplicationConstants;

namespace Photography.Controllers
{
    [Authorize(Roles = AdminRoleName)]
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
            var categories = await categoryService.GetAllCategoriesAsync();

            return View(categories);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.AddCategoryAsync(model);

            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Guid categoryGuid = Guid.Empty;
            if (!IsGuidValid(id, ref categoryGuid))
            {
                return Unauthorized();
            }

            var model = await categoryService.GetCategoryToEditAsync(categoryGuid);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryFormViewModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                return Unauthorized();
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
            Guid categoryIdGuid = Guid.Empty;
            if (!IsGuidValid(id, ref categoryIdGuid))
            {
                return Unauthorized();
            }

            var model = await categoryService.GetCategoryDelete(categoryIdGuid);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryFormViewModel model)
        {
            bool isDeleted = await categoryService.DeleteCategoryAsync(model.Id);

            if (!isDeleted)
            {
                TempData["ErrorMessage"] = "Възникна неочаквана грешка. Категорията не беше изтрита.";
                return RedirectToAction(nameof(Delete), new { id = model.Id });
            }

            return RedirectToAction("Manage", "Category");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.Category;
using Photography.Core.ViewModels.Photo;

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

        [HttpGet]
        public async Task<IActionResult> Edit( string id)
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

            var model = await categoryService.GetCategoryToEditAsync(categoryGuid);
            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
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
        public IActionResult Remove()
        {
            return View();
        }
    }

}

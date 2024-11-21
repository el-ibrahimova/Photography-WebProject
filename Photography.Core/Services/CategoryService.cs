using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Category;
using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;

namespace Photography.Core.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly PhotographyDbContext context;

        public CategoryService(PhotographyDbContext data)
            : base(data)
        {
            context = data;
        }

        public async Task AddCategoryAsync(AddCategoryViewModel model)
        {
            Category category = new Category()
            {
                Name = model.Name
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<EditCategoryViewModel> GetCategoryToEditAsync(Guid categoryGuid)
        {
            var category = await context.Categories
                .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new ArgumentException("Категорията не съществува");
            }

            var model = new EditCategoryViewModel()
            {
                Name = category.Name
            };

            return model;
        }

        public async Task<bool> EditCategoryAsync(EditCategoryViewModel model)
        {
            if (!Guid.TryParse(model.Id.ToString(), out Guid categoryIdGuid))
            {
                return false;
            }

            var category = await context.Categories
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return false;
            }

            category.Name = model.Name;

            await context.SaveChangesAsync();

            return true;
        }
    }
}
}

using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;


namespace Photography.Core.Services
{
    using Photography.Core.ViewModels.Category;
    using Photography.Core.ViewModels.Photo;

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

        public async Task<CategoryFormViewModel> GetCategoryToEditAsync(string categoryId)
        {
            var category = await context.Categories
                .Where(c=>c.IsDeleted==false && c.Id.ToString().ToLower() == categoryId.ToLower())
                .FirstOrDefaultAsync();

            if (category == null)
            {
                throw new ArgumentException("Категорията не съществува");
            }

            var model = new CategoryFormViewModel()
            {
                Id = category.Id.ToString(),
                Name = category.Name
            };

            return model;
        }

        public async Task<bool> EditCategoryAsync(CategoryFormViewModel model)
        {
            if (!Guid.TryParse(model.Id.ToString(), out Guid categoryIdGuid))
            {
                return false;
            }

            var category = await context.Categories
                .Where(c => c.IsDeleted == false && c.Id.ToString().ToLower() == model.Id.ToLower())
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return false;
            }

            category.Name = model.Name;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<CategoryFormViewModel?> GetCategoryDelete(string categoryId)
        {
            return await context.Categories
                .AsNoTracking()
                .Where(c => c.Id.ToString().ToLower() == categoryId.ToLower() && c.IsDeleted == false)
                .Select(c => new CategoryFormViewModel()
                {
                    Name = c.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Category> DeleteCategoryAsync(string categoryId)
        {
            var category = await context.Categories
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == categoryId.ToLower() && c.IsDeleted == false);

            if (category == null)
            {
                throw new ArgumentException("Категорията не съществува");
            }

            category.IsDeleted = true;
            await context.SaveChangesAsync();

            return category;
        }

        public async Task<ICollection<AllCategoryViewModel>> GetAllCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Where(c => c.IsDeleted == false)
                .Select(c => new AllCategoryViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    PhotosCategories = c.PhotosCategories
                })
                .ToListAsync();
        }
    }

}

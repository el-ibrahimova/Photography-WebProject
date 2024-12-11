namespace Photography.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using ViewModels.Category;

    public class CategoryService : BaseService, ICategoryService
    {
        private readonly PhotographyDbContext context;

        public CategoryService(PhotographyDbContext data)
            : base(data)
        {
            context = data;
        }


        public async Task<bool> AddCategoryAsync(AddCategoryViewModel model)
        {
            Category category = new Category()
            {
                Name = model.Name
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryFormViewModel?> GetCategoryToEditAsync(string categoryId)
        {
            Category? category = await context.Categories
                .Where(c => c.Id.ToString().ToLower() == categoryId.ToLower() && c.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return null;
            }

            var model = new CategoryFormViewModel()
            {
                Id = category.Id.ToString(),
                Name = category.Name
            };

            return model;
        }

        public async Task<bool> EditCategoryAsync(CategoryFormViewModel? model)
        {
            if (model == null)
            {
                return false;
            }

            Category? category = await context.Categories
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

        public async Task<bool> DeleteCategoryAsync(string categoryId)
        {
            Category? category = await context.Categories
                .Include(p => p.PhotosCategories)
                .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id.ToString().ToLower() == categoryId.ToLower());

            if (category == null)
            {
                return false;
            }

            category.IsDeleted = true;
            await context.SaveChangesAsync();

            List<PhotoCategory> photosCategoriesToRemove = context.PhotosCategories
                   .Where(pc => pc.CategoryId.ToString().ToLower() == category.Id.ToString().ToLower())
                   .ToList();

            if (photosCategoriesToRemove.Any())
            {
                context.PhotosCategories.RemoveRange(photosCategoriesToRemove);
                await context.SaveChangesAsync();
            }

            return true;
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

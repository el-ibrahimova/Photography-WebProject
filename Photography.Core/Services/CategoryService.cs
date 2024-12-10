using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;


namespace Photography.Core.Services
{
    using Photography.Core.ViewModels.Category;

    public class CategoryService : BaseService, ICategoryService
    {
        private readonly PhotographyDbContext context;
        private readonly IPhotoService photoService;

        public CategoryService(PhotographyDbContext data, IPhotoService _photoService)
            : base(data)
        {
            context = data;
            photoService = _photoService;
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

        public async Task<CategoryFormViewModel?> GetCategoryToEditAsync(Guid categoryId)
        {
            Category? category = await context.Categories
                .Where(c =>c.Id == categoryId && c.IsDeleted == false)
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

        public async Task<CategoryFormViewModel?> GetCategoryDelete(Guid categoryId)
        {
            return await context.Categories
                .AsNoTracking()
                .Where(c => c.Id== categoryId && c.IsDeleted == false)
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
                .FirstOrDefaultAsync(c => c.IsDeleted == false&&  c.Id.ToString().ToLower() == categoryId.ToLower());

            if (category == null)
            {
                return false;
            }

            category.IsDeleted = true;
            await context.SaveChangesAsync();

         List<PhotoCategory> photosCategoriesToRemove = context.PhotosCategories
                .Where(pc => pc.CategoryId == category.Id)
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

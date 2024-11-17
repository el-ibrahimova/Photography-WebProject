using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Category;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Services
{
    public class CategoryService : BaseService,ICategoryService
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
    }
}

namespace Photography.Core.Interfaces
{
    using Infrastructure.Data.Models;
    using ViewModels.Category;

    public interface ICategoryService:IBaseService
    {
        Task<bool> AddCategoryAsync(AddCategoryViewModel model);
        Task<CategoryFormViewModel?> GetCategoryToEditAsync(Guid categoryId);
        Task<bool> EditCategoryAsync(CategoryFormViewModel? model);

        Task<CategoryFormViewModel?> GetCategoryDelete(Guid categoryId);
        Task<bool> DeleteCategoryAsync(string categoryId);

        Task<ICollection<AllCategoryViewModel>> GetAllCategoriesAsync();
    }
}

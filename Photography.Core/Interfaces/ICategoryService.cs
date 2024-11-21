namespace Photography.Core.Interfaces
{
    using Infrastructure.Data.Models;
    using ViewModels.Category;

    public interface ICategoryService:IBaseService
    {
        Task<AddCategoryViewModel> GetAddCategoryAsync();
        Task AddCategoryAsync(AddCategoryViewModel model);
        Task<CategoryFormViewModel> GetCategoryToEditAsync(string categoryId);
        Task<bool> EditCategoryAsync(CategoryFormViewModel model);

        Task<CategoryFormViewModel?> GetCategoryDelete(string categoryId);
        Task<Category> DeleteCategoryAsync(string categoryId);

        Task<ICollection<AllCategoryViewModel>> GetAllCategoriesAsync();
    }
}

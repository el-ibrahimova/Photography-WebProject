namespace Photography.Core.Interfaces
{
    using Photography.Core.ViewModels.Photo;
    using ViewModels.Category;
    public interface ICategoryService:IBaseService
    {
        Task AddCategoryAsync(AddCategoryViewModel model);
        Task<EditCategoryViewModel> GetCategoryToEditAsync(Guid categoryGuid);
        Task<bool> EditCategoryAsync(EditCategoryViewModel model);
    }
}

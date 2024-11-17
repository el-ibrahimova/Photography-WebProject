
using Photography.Core.ViewModels.Category;

namespace Photography.Core.Interfaces
{
    public interface ICategoryService:IBaseService
    {
        Task AddCategoryAsync(AddCategoryViewModel model);
    }
}

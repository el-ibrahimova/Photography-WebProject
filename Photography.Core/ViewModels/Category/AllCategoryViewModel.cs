using Photography.Infrastructure.Data.Models;

namespace Photography.Core.ViewModels.Category
{
    public class AllCategoryViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public ICollection<PhotoCategory> PhotosCategories { get; set; } = new HashSet<PhotoCategory>();
    }
}

namespace Photography.Core.ViewModels.Category
{
    using Infrastructure.Data.Models;
    public class AllCategoryViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public ICollection<PhotoCategory> PhotosCategories { get; set; } = new HashSet<PhotoCategory>();
    }
}

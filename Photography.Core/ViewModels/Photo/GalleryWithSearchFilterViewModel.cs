namespace Photography.Core.ViewModels.Photo
{
    public class GalleryWithSearchFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public string? CategoryFilter { get; set; }
        public string? DateFilter { get; set; }  
        public ICollection<string>? AllCategories { get; set; }
        public ICollection<GalleryViewModel>? Gallery { get; set; }
    }
 
}

namespace Photography.Core.ViewModels.Photo
{
    public class GalleryWithSearchFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public string? CategoryFilter { get; set; }
        public string? DateFilter { get; set; }  
        public ICollection<string>? AllCategories { get; set; }
        public ICollection<GalleryViewModel>? Gallery { get; set; }


        public int? CurrentPage { get; set; } = 1;
        public int? EntitiesPerPage { get; set; } = 8;
        public int? TotalPages { get; set; }
    }
 
}

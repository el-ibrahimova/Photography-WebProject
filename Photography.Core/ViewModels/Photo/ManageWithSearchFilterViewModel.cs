namespace Photography.Core.ViewModels.Photo
{
    public class ManageWithSearchFilterViewModel
    {
        public string? SearchQuery { get; set; }
        public string? CategoryFilter { get; set; }
        public string? DateFilter { get; set; }
        public ICollection<string>? AllCategories { get; set; }
        public ICollection<AllPhotosViewModel>? AllPhotos { get; set; }


        public int? CurrentPage { get; set; } = 1;
        public int? EntitiesPerPage { get; set; } = 10;
        public int? TotalPages { get; set; }
    }
}

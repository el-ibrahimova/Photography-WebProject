namespace Photography.Core.ViewModels.Photo
{
    using Infrastructure.Data.Models;
    public class AllPhotosViewModel
    {
        public string Id { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Rating { get; set; }
        public ApplicationUser UserOwner { get; set; } = null!;
    }
}

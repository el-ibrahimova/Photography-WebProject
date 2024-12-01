namespace Photography.Core.ViewModels.PhotoShoot
{
    public class UserPhotoShootsViewModel
    {
        public string Id { get; set; } = null!;
        public string ImageUrl1 { get; set; } = null!;
        public string? ImageUrl2 { get; set; } = null!;
        public string? ImageUrl3 { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PhotographerId { get; set; } = null!;

    }
}

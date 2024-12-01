namespace Photography.Core.ViewModels.PhotoShoot
{
    public class DeletePhotoShootViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string PhotographerId { get; set; } = null!;
    }
}

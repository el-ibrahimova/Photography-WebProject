namespace Photography.Core.ViewModels.Admin.UserManagement
{
    using Photographer;
    public class AllUsersViewModel
    {
        public string Id { get; set; } = null!;
        public string? Email { get; set; }
        public IEnumerable<string> Roles { get; set; } = null!;
        public IEnumerable<PhotographerViewModel> Photographers { get; set; } = new HashSet<PhotographerViewModel>();
    }
}

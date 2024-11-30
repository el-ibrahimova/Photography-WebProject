namespace Photography.Core.Interfaces
{
    public interface IPhotographerService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task CreateAsync(string userId, string brandName);

        Task<bool> UserWithBrandNameExistAsync(string brandName);
    }
}

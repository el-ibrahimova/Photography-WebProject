namespace Photography.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    public class PhotographerService : BaseService, IPhotographerService
    {
        private readonly PhotographyDbContext context;

        public PhotographerService(PhotographyDbContext data)
            : base(data)
        {
            context = data;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await context.Photographers
                .AnyAsync(p => p.UserId.ToString().ToLower() == userId.ToLower());
        }

        public async Task<bool> CreateAsync(string userId, string brandName)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id.ToString().ToLower() == userId.ToLower());

            if (user == null)
            {
                return false;
            }

            var photographer = new Photographer
            {
                BrandName = brandName,
                UserId = Guid.Parse(userId)
            };

            context.Photographers.Add(photographer);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserWithBrandNameExistAsync(string brandName)
        {
            return await context.Photographers.AnyAsync(p => p.BrandName == brandName);
        }
    }
}

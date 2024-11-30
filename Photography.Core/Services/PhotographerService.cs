using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Services
{
    public class PhotographerService:BaseService,IPhotographerService
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
                .AnyAsync(p=>p.UserId.ToString().ToLower()== userId.ToLower());
        }

        public async Task CreateAsync(string userId, string brandName)
        {
            await context.AddAsync(new Photographer()
            {
                UserId = Guid.Parse(userId),
                BrandName = brandName
            });
        }

        public async Task<bool> UserWithBrandNameExistAsync(string brandName)
        {
          return  await context.Photographers.AnyAsync(p => p.BrandName == brandName);
        }
    }
}

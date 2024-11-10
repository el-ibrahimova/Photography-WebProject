using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Gallery;
using Photography.Data;

namespace Photography.Core.Services
{
    public class GalleryService: BaseService, IGalleryService
    {
        private readonly PhotographyDbContext context;

        public GalleryService(PhotographyDbContext data)
        {
            context = data;
        }
        public async Task<IEnumerable<GalleryViewModel>> GetGalleryAsync()
        {
            var photos = await context.Photos
                .Where(p => !p.IsPrivate && p.IsDeleted == false)
                .Select(p => new GalleryViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    Rating = p.Rating
                })
                .ToListAsync();

            return photos;
        }

        public async Task<IEnumerable<MyGalleryViewModel>> GetPrivateGalleryAsync(Guid userId)
        {
            var model = await context.Photos
                .AsNoTracking()
                .Where(p => !p.IsPrivate || p.UserOwnerId == userId && p.IsDeleted == false)
                .Select(p => new MyGalleryViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    UserOwnerId = userId.ToString()
                })
                .ToListAsync();

            return model;
        }
    }
}

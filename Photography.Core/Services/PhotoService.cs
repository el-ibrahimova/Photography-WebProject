using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photo;
using Photography.Data;

namespace Photography.Core.Services
{
    public class PhotoService:BaseService, IPhotoService
    {
        private readonly PhotographyDbContext context;

        public PhotoService(PhotographyDbContext data)
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
    }
}

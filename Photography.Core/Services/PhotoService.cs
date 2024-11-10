using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Gallery;
using Photography.Core.ViewModels.Photo;
using Photography.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Services
{
    using static Common.ApplicationConstants;
    public class PhotoService : BaseService, IPhotoService
    {
        private readonly PhotographyDbContext context;

        public PhotoService(PhotographyDbContext data)
        {
            context = data;
        }

        public async Task<AddPhotoViewModel> GetAddPhotoAsync()
        {
            var model = new AddPhotoViewModel()
            {
                Categories = await GetCategoriesAsync(),
                UserPhotoOwners = await GetAllUsersAsync()
            };

            return model;
        }

        public async Task AddPhotoAsync(AddPhotoViewModel model, string userId)
        {
            DateTime uploadedAt;

            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out uploadedAt))
            {
                throw new InvalidOperationException($"Невалиден формат за дата. Датата трябва да бъде във формат: {EntityDateFormat}");
            }

            if (model.IsPrivate && string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("Невалиден потребител");
            }

            var userOwnerId = model.UserOwnerId;

            var photo = new Photo
            {
                Title = model.Title,
                Description = model.Description,
                UploadedAt = uploadedAt,
                ImageUrl = model.ImageUrl,
                IsPrivate = model.IsPrivate,
                UserOwnerId =
                    model.IsPrivate
                        ? userOwnerId
                        : Guid.Parse(userId), //  save userOwnerId only if photo is private, or else save it to userId
                PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory() { CategoryId = id })
                    .ToList()
            };

            await context.Photos.AddAsync(photo);
            await context.SaveChangesAsync();
        }

        public async Task IncreaseRatingAsync(Guid photoIdGuid, Guid userIdGuid)
        {
            var photo = await context
                .Photos.Where(p => p.Id == photoIdGuid && p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
               throw new InvalidOperationException("Снимката не е намерена.");
            }

            bool hasUserRated = await context
                .PhotosRatings.AnyAsync(r => r.PhotoId == photoIdGuid && r.UserId == userIdGuid);

            if (!hasUserRated)
            {
                photo.Rating += 1;

                var photoRating = new PhotoRating
                {
                    PhotoId = photoIdGuid,
                    UserId = userIdGuid
                };
                context.PhotosRatings.Add(photoRating);

                await context.SaveChangesAsync();
            }
        }

        public async Task<DetailsViewModel> GetPhotoDetailsAsync(Guid photoGuid)
        {
            var photo = await context.Photos
                .Include(p => p.Owner)
                .Include(p => p.PhotosCategories)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == photoGuid);

            if (photo == null || photo.IsDeleted == true)
            {
                return null;
            }

           return new DetailsViewModel()
            {
                Id = photo.Id.ToString(),
                Title = photo.Title,
                ImageUrl = photo.ImageUrl,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                IsFavorite = photo.IsFavorite,
                IsPrivate = photo.IsPrivate,
                IsDeleted = photo.IsDeleted,
                Rating = photo.Rating,
                UserOwnerId = photo.UserOwnerId,
                Categories = photo.PhotosCategories.Select(p => p.Category.Name).ToList(),
                Owner = photo.Owner,
            };
        }




        public async Task<ICollection<CategoryViewModel>> GetCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<ICollection<UserViewModel>> GetAllUsersAsync()
        {
            return await context.Users
                  .AsNoTracking()
                  .Select(u => new UserViewModel()
                  {
                      Id = u.Id.ToString(),
                      UserName = u.UserName ?? String.Empty
                  }).ToListAsync();
        }
    }
}

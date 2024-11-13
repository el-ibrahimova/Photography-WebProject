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

        public async Task<Photo> GetPhotoByIdAsync(Guid photoIdGuid)
        {
            return await context.Photos
                .Where(p => !p.IsDeleted && p.Id == photoIdGuid)
                .FirstOrDefaultAsync();
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

        public async Task<bool> HasUserRatedAsync(Guid photoIdGuid, Guid userIdGuid)
        {
            return await context.PhotosRatings
                .AnyAsync(r => r.PhotoId == photoIdGuid && r.UserId == userIdGuid);
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
                PhotoOwner = photo.Owner!.UserName 
            };
        }

        public async Task<ICollection<FavoriteViewModel>> GetFavoritePhotosAsync(string userId)
        {
            return await context.FavoritePhotos
                 .AsNoTracking()
                 .Where(fp => fp.UserId.ToString() == userId && fp.Photo.IsDeleted == false)
                 .Select(fp => new FavoriteViewModel()
                 {
                     Id = fp.Photo.Id.ToString(),
                     ImageUrl = fp.Photo.ImageUrl,
                     Title = fp.Photo.Title,
                 })
                 .ToListAsync();
        }

        public async Task AddPhotoToFavoritesAsync(Guid userGuid, Guid photoGuid)
        {
            var photo = await context.Photos
                .Where(p => p.IsDeleted == false && p.Id == photoGuid)
                .Include(fp => fp.FavoritePhotos)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                throw new ArgumentException("Снимката не съществува");
            }

            if (!context.FavoritePhotos.Any(fp => fp.UserId == userGuid && fp.PhotoId == photoGuid))
            {
                photo.FavoritePhotos.Add(new FavoritePhoto()
                {
                    UserId = userGuid,
                    PhotoId = photoGuid
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemovePhotoFromFavoritesAsync(string userId, string photoId)
        {
            var photo = await context.Photos
                .Where(p => !p.IsDeleted && p.Id.ToString() == photoId)
                .Include(p => p.FavoritePhotos)
                .FirstOrDefaultAsync();

            var user = await context.FavoritePhotos
                .Where(u => u.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (photo == null || user == null)
            {
                throw new ArgumentException("Снимката или потребителят не съществуват");
            }

            context.FavoritePhotos.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<EditPhotoViewModel> GetPhotoToEditAsync(Guid photoGuid)
        {
            var photo = await context.Photos
                .Include(p => p.PhotosCategories) // 
                .Where(p => p.IsDeleted == false && p.Id == photoGuid)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                throw new ArgumentException("Снимката не съществува");
            }

            var model = new EditPhotoViewModel()
            {
                Title = photo.Title,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                ImageUrl = photo.ImageUrl,
                IsPrivate = photo.IsPrivate,
                UserOwnerId = photo.UserOwnerId,
                Categories = await GetCategoriesAsync(),
                UserPhotoOwners = await GetAllUsersAsync()
            };

            return model;
        }

        public async Task<bool> EditPhotoAsync(EditPhotoViewModel model)
        {
            if (!Guid.TryParse(model.Id.ToString(), out Guid photoIdGuid))
            {
                return false; 
            }

            var photo = await context.Photos
                .Include(p => p.PhotosCategories)
                .Where(p => !p.IsDeleted && p.Id == photoIdGuid)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return false; 
            }

            if (!Guid.TryParse(model.UserOwnerId.ToString(), out Guid userIdGuid) || photo.UserOwnerId != userIdGuid)
            {
                return false; 
            }

            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime uploadedAt))
            {
                return false; 
            }

            photo.Title = model.Title;
            photo.ImageUrl = model.ImageUrl;
            photo.Description = model.Description;
            photo.IsPrivate = model.IsPrivate;
            photo.UserOwnerId = model.UserOwnerId;
            photo.UploadedAt = uploadedAt;
            photo.PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory { CategoryId = id }).ToList();

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteViewModel> GetPhotoDelete(string photoId)
        {
          return await context.Photos
                .AsNoTracking()
                .Where(p => p.IsDeleted == false && p.Id.ToString() == photoId)
                .Select(p => new DeleteViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    UploadedAt = p.UploadedAt.ToString(EntityDateFormat),
                    DeletedAt = null,
                    UserOwnerId = p.UserOwnerId.ToString(),
                    Owner = p.Owner.UserName
                })
                .FirstOrDefaultAsync();
        }
        
        public async Task<Photo> DeletePhotoAsync(string photoId)
        {
            var photoToDelete = await context.Photos
              .FirstOrDefaultAsync(p => p.Id.ToString() == photoId);

            photoToDelete.IsDeleted = true;
            photoToDelete.DeletedAt = DateTime.Now;

            await context.SaveChangesAsync();
            return photoToDelete;
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

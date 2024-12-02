using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace Photography.Core.Services
{
    using static Common.ApplicationConstants;
    public class PhotoService : BaseService, IPhotoService
    {
        private readonly PhotographyDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public PhotoService(PhotographyDbContext data, UserManager<ApplicationUser> _userManager)
            : base(data)
        {
            context = data;
            userManager= _userManager;
        }

        public async Task<Photo?> GetPhotoByIdAsync(Guid photoIdGuid)
        {
            return await context.Photos
                .Where(p => !p.IsDeleted && p.Id == photoIdGuid)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GalleryViewModel>> GetGalleryAsync()
        {
            List<GalleryViewModel> photos = await context.Photos
                .Where(p => !p.IsPrivate && p.IsDeleted == false)
                .Select(p => new GalleryViewModel()
                {
                    Id = p.Id.ToString(),
                    TagUser = p.TagUser,
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
                    TagUser = p.TagUser,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    UserOwnerId = userId.ToString()
                })
                .ToListAsync();

            return model;
        }

        public async Task<AddPhotoViewModel> GetAddPhotoAsync()
        {
            AddPhotoViewModel model = new AddPhotoViewModel()
            {
                Categories = await GetCategoriesAsync(),
                UserPhotoOwners = await GetAllUsersAsync()
            };

            return model;
        }

        public async Task<bool> AddPhotoAsync(AddPhotoViewModel model, string userId)
        {
            DateTime uploadedAt;

            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out uploadedAt))
            {
                return false;
            }

            if (string.IsNullOrEmpty(userId) && model.IsPrivate)
            {
                return false;
            }

            Guid userOwnerId = Guid.Empty;

            if (!model.IsPrivate)
            {
                userOwnerId = Guid.Parse(userId);
            }
            else
            {
                userOwnerId = model.UserOwnerId;
            }

            var photo = new Photo
            {
                TagUser = model.TagUser,
                Description = model.Description,
                UploadedAt = uploadedAt,
                ImageUrl = model.ImageUrl,
                IsPrivate = model.IsPrivate,
                UserOwnerId = userOwnerId,
                PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory() { CategoryId = id })
                    .ToList()
            };
            
                await context.Photos.AddAsync(photo);
                await context.SaveChangesAsync();
                return true;
        }

        public async Task IncreaseRatingAsync(Guid photoIdGuid, Guid userIdGuid)
        {
            Photo? photo = await context
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
        
        public async Task<DetailsViewModel?> GetPhotoDetailsAsync(Guid photoGuid)
        {
            Photo? photo = await context.Photos
                .Include(p => p.Owner)
                .Include(p => p.PhotosCategories)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == photoGuid&& p.IsDeleted==false);

            
            return new DetailsViewModel()
            {
                Id = photo.Id.ToString(),
                TagUser = photo.TagUser,
                ImageUrl = photo.ImageUrl,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                IsPrivate = photo.IsPrivate,
                IsDeleted = photo.IsDeleted,
                Rating = photo.Rating,
                UserOwnerId = photo.UserOwnerId,
                Categories = photo.PhotosCategories.Select(p => p.Category.Name).ToList(),
                Owner = photo.Owner,
                PhotoOwner = photo.Owner!.UserName
            };
        }

        public async Task<ICollection<FavoriteViewModel>> GetFavoritePhotosAsync(Guid userId)
        {
            return await context.FavoritePhotos
                 .AsNoTracking()
                 .Where(fp => fp.UserId== userId && fp.Photo.IsDeleted == false)
                 .Select(fp => new FavoriteViewModel()
                 {
                     Id = fp.Photo.Id.ToString(),
                     ImageUrl = fp.Photo.ImageUrl,
                     TagUser = fp.Photo.TagUser,
                 })
                 .ToListAsync();
        }

        public async Task<bool> AddPhotoToFavoritesAsync(Guid userGuid, Guid photoGuid)
        {
            Photo? photo = await context.Photos
                .Where(p => p.IsDeleted == false && p.Id == photoGuid)
                .Include(fp => fp.FavoritePhotos)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return false;
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

            return true;
        }

        public async Task<bool> RemovePhotoFromFavoritesAsync(string userId, string photoId)
        {
            Photo? photo = await context.Photos
                .Where(p => !p.IsDeleted && p.Id.ToString() == photoId)
                .Include(p => p.FavoritePhotos)
                .FirstOrDefaultAsync();

            FavoritePhoto? favoritePhoto = await context.FavoritePhotos
                .Where(u => u.UserId.ToString() == userId)
                .FirstOrDefaultAsync();

            if (photo == null || favoritePhoto == null)
            {
                return false;
            }

            context.FavoritePhotos.Remove(favoritePhoto);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<EditPhotoViewModel?> GetPhotoToEditAsync(Guid photoGuid)
        {
            Photo? photo = await context.Photos
                .Include(p => p.PhotosCategories)
                .Where(p => p.IsDeleted == false && p.Id == photoGuid)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return null;
            }

            var model = new EditPhotoViewModel()
            {
                TagUser = photo.TagUser,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                ImageUrl = photo.ImageUrl,
                IsPrivate = photo.IsPrivate,
                UserOwnerId = photo.UserOwnerId.ToString(),
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

            Photo? photo = await context.Photos
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

            DateTime uploadedAt;
            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out uploadedAt))
            {
                return false;
            }

            photo.TagUser = model.TagUser;
            photo.ImageUrl = model.ImageUrl;
            photo.Description = model.Description;
            photo.IsPrivate = model.IsPrivate;
            photo.UserOwnerId = Guid.Parse(model.UserOwnerId);
            photo.UploadedAt = uploadedAt;
            photo.PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory { CategoryId = id }).ToList();

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteViewModel?> GetPhotoDelete(Guid photoId)
        {
            return await context.Photos
                  .AsNoTracking()
                  .Where(p => p.IsDeleted == false && p.Id== photoId)
                  .Select(p => new DeleteViewModel()
                  {
                      Id = p.Id.ToString(),
                      TagUser = p.TagUser,
                      UploadedAt = p.UploadedAt.ToString(EntityDateFormat),
                      DeletedAt = null,
                      UserOwnerId = p.UserOwnerId.ToString(),
                      Owner = p.Owner.UserName
                  })
                  .FirstOrDefaultAsync();
        }

        public async Task<bool> DeletePhotoAsync(string photoId)
        {
            Photo? photoToDelete = await context.Photos
                .FirstOrDefaultAsync(p => p.Id.ToString() == photoId && p.IsDeleted==false);

            if (photoToDelete == null)
            {
                return false;
            }

            photoToDelete.IsDeleted = true;
            photoToDelete.DeletedAt = DateTime.Now;

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<CategoryViewModel>> GetCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Where(c => c.IsDeleted == false)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<ICollection<UserViewModel>> GetAllUsersAsync()
        {
            Guid adminRoleId = await context.Roles
                .Where(r => r.Name == AdminRoleName)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            List<UserViewModel> user = await context.Users
                  .AsNoTracking()
                  .Where(u => !context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == adminRoleId))
                  .Select(u => new UserViewModel()
                  {
                      Id = u.Id.ToString(),
                      UserName = u.UserName ?? String.Empty
                  }).ToListAsync();

            return user;
        }

        public async Task<ICollection<AllPhotosViewModel>> GetAllPhotosAsync()
        {
            var photos = await context.Photos
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.UploadedAt)
                .Select(p => new AllPhotosViewModel()
                {
                    Id = p.Id.ToString(),
                    ImageUrl = p.ImageUrl,
                    UserOwner = p.Owner,
                    Rating = p.Rating
                })
                .ToListAsync();

            return photos;
        }
    }
}

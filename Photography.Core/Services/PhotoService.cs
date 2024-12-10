using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Photography.Core.Services
{
    using static Common.ApplicationConstants;
    using static Common.EntityConstants.Photo;
    public class PhotoService : BaseService, IPhotoService
    {
        private readonly PhotographyDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public PhotoService(PhotographyDbContext data, UserManager<ApplicationUser> _userManager)
            : base(data)
        {
            context = data;
            userManager = _userManager;
        }

        public async Task<Photo?> GetPhotoByIdAsync(Guid photoIdGuid)
        {
            return await context.Photos
                .Where(p => p.Id == photoIdGuid && !p.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<GalleryViewModel>> GetGalleryAsync(GalleryWithSearchFilterViewModel model)
        {
            IQueryable<Photo> allPhotosQuery = context
                .Photos
                .Where(p => p.IsPrivate == false && !p.IsDeleted)
                .AsQueryable();


            if (!String.IsNullOrWhiteSpace(model.SearchQuery))
            {
                allPhotosQuery = allPhotosQuery
                    .Where(p =>
                    (p.TagUser ?? string.Empty).ToLower().Contains(model.SearchQuery.ToLower()));
            }

            if (!String.IsNullOrWhiteSpace(model.CategoryFilter))
            {
                allPhotosQuery = allPhotosQuery.Where(p =>
                    p.PhotosCategories.Any(pc => pc.Category.Name.ToLower() == model.CategoryFilter.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(model.DateFilter))
            {
                Match rangeMatch = Regex.Match(model.DateFilter, DateRegexFormat);

                if (rangeMatch.Success)
                {
                    int startMonth = int.Parse(rangeMatch.Groups[1].Value);
                    int startYear = int.Parse(rangeMatch.Groups[2].Value);
                    int endMonth = int.Parse(rangeMatch.Groups[3].Value);
                    int endYear = int.Parse(rangeMatch.Groups[4].Value);

                    if (startYear < endYear)
                    {
                        allPhotosQuery = allPhotosQuery.Where(p =>
                                              p.UploadedAt.Year >= startYear && p.UploadedAt.Year <= endYear);
                    }
                    else if (startYear == endYear)
                    {
                        allPhotosQuery = allPhotosQuery.Where(p =>
                            (p.UploadedAt.Year >= startYear && p.UploadedAt.Year <= endYear) &&
                            (p.UploadedAt.Month >= startMonth && p.UploadedAt.Month <= endMonth));
                    }

                }
                else if (int.TryParse(model.DateFilter, out int date))
                {
                    allPhotosQuery = allPhotosQuery.Where(m => m.UploadedAt.Year == date);
                }
            }

            if (model.CurrentPage.HasValue && model.EntitiesPerPage.HasValue)
            {
                allPhotosQuery = allPhotosQuery
                    .Skip(model.EntitiesPerPage.Value * (model.CurrentPage.Value - 1))
                    .Take(model.EntitiesPerPage.Value);
            }

            return await allPhotosQuery
                .Select(p => new GalleryViewModel
                {
                    Id = p.Id.ToString(),
                    TagUser = p.TagUser,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    Rating = p.Rating
                })
                .ToArrayAsync();
        }

        public async Task<ICollection<GalleryViewModel>> GetPrivateGalleryAsync(GalleryWithSearchFilterViewModel model, Guid userId)
        {
            IQueryable<Photo> allPhotosQuery = context
                .Photos
                .Where(p => p.IsPrivate == true && p.UserOwnerId == userId && !p.IsDeleted)
                .AsQueryable();


            if (!String.IsNullOrWhiteSpace(model.SearchQuery))
            {
                allPhotosQuery = allPhotosQuery
                    .Where(p =>
                        (p.TagUser ?? string.Empty).ToLower().Contains(model.SearchQuery.ToLower()));
            }

            if (!String.IsNullOrWhiteSpace(model.CategoryFilter))
            {
                allPhotosQuery = allPhotosQuery.Where(p =>
                    p.PhotosCategories.Any(pc => pc.Category.Name.ToLower() == model.CategoryFilter.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(model.DateFilter))
            {
                Match rangeMatch = Regex.Match(model.DateFilter, DateRegexFormat);

                if (rangeMatch.Success)
                {
                    int startMonth = int.Parse(rangeMatch.Groups[1].Value);
                    int startYear = int.Parse(rangeMatch.Groups[2].Value);
                    int endMonth = int.Parse(rangeMatch.Groups[3].Value);
                    int endYear = int.Parse(rangeMatch.Groups[4].Value);

                    if (startYear < endYear)
                    {
                        allPhotosQuery = allPhotosQuery.Where(p =>
                            p.UploadedAt.Year >= startYear && p.UploadedAt.Year <= endYear);
                    }
                    else if (startYear == endYear)
                    {
                        allPhotosQuery = allPhotosQuery.Where(p =>
                            (p.UploadedAt.Year >= startYear && p.UploadedAt.Year <= endYear) &&
                            (p.UploadedAt.Month >= startMonth && p.UploadedAt.Month <= endMonth));
                    }

                }
                else if (int.TryParse(model.DateFilter, out int date))
                {
                    allPhotosQuery = allPhotosQuery.Where(m => m.UploadedAt.Year == date);
                }
            }


            if (model.CurrentPage.HasValue && model.EntitiesPerPage.HasValue)
            {
                allPhotosQuery = allPhotosQuery
                    .Skip(model.EntitiesPerPage.Value * (model.CurrentPage.Value - 1))
                    .Take(model.EntitiesPerPage.Value);
            }

            return await allPhotosQuery
                .Select(p => new GalleryViewModel
                {
                    Id = p.Id.ToString(),
                    TagUser = p.TagUser,
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    Rating = p.Rating,
                    UserOwnerId = userId.ToString()
                })
                .ToArrayAsync();
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

            Guid? userOwnerId = null;

            if (model.IsPrivate)
            {
                if (string.IsNullOrEmpty(model.UserOwnerId) || !Guid.TryParse(model.UserOwnerId, out var parsedGuid))
                {
                    return false;
                }
                userOwnerId = parsedGuid;
            }

            Guid photographerId = await context.Photographers
                .Where(p => p.UserId.ToString() == userId)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();

            Photo? photo = new Photo
            {
                TagUser = model.TagUser,
                Description = model.Description,
                UploadedAt = uploadedAt,
                ImageUrl = model.ImageUrl,
                IsPrivate = model.IsPrivate,
                UserOwnerId = userOwnerId,
                PhotographerId = photographerId,
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
                .Photos.Where(p => p.Id == photoIdGuid && !p.IsDeleted)
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
                 .Include(p => p.Photographer)
                .Include(p => p.PhotosCategories)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == photoGuid && !p.IsDeleted);


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
                UserOwnerId = photo.UserOwnerId.ToString(),
                Photographer = photo.Photographer,
                Categories = photo.PhotosCategories.Select(p => p.Category.Name).ToList(),
            };
        }

        public async Task<ICollection<FavoriteViewModel>> GetFavoritePhotosAsync(Guid userId)
        {
            return await context.FavoritePhotos
                 .AsNoTracking()
                 .Where(fp => fp.UserId == userId && fp.Photo.IsDeleted == false)
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
                .Where(p => p.Id == photoGuid && !p.IsDeleted)
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
                .Where(p => p.Id.ToString() == photoId && !p.IsDeleted)
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
                .Include(p => p.Photographer)
                .Include(p => p.PhotosCategories)
                .Where(p => p.Id == photoGuid && p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return null;
            }

            var model = new EditPhotoViewModel()
            {
                Id = photo.Id.ToString(),
                TagUser = photo.TagUser,
                Description = photo.Description,
                UploadedAt = photo.UploadedAt.ToString(EntityDateFormat),
                ImageUrl = photo.ImageUrl,
                IsPrivate = photo.IsPrivate,
                UserOwnerId = photo.UserOwnerId.ToString(),
                UserPhotographerId = photo.Photographer.UserId.ToString(),
                Categories = await GetCategoriesAsync(),
                UserPhotoOwners = await GetAllUsersAsync()
            };

            return model;
        }

        public async Task<bool> EditPhotoAsync(EditPhotoViewModel model)
        {
            Guid photoIdGuid = Guid.Empty;
            if (!IsGuidValid(model.Id, ref photoIdGuid))
            {
                return false;
            }

            Photo? photo = await context.Photos
                .Include(p => p.Photographer)
                .Include(p => p.PhotosCategories)
                .Where(p => p.Id == photoIdGuid && !p.IsDeleted)
                .FirstOrDefaultAsync();


            if (photo == null)
            {
                return false;
            }

            var userPhotographerId = photo.Photographer.UserId;
           
            Guid modelPhotographer = Guid.Empty;
            if (!IsGuidValid(model.UserPhotographerId, ref modelPhotographer) || modelPhotographer !=userPhotographerId)
            {
                return false;
            }

            DateTime uploadedAt;
            if (!DateTime.TryParseExact(model.UploadedAt, EntityDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out uploadedAt))
            {
                return false;
            }

            Guid? userOwnerId = null;

            if (model.IsPrivate)
            {
                if (string.IsNullOrEmpty(model.UserOwnerId) || !Guid.TryParse(model.UserOwnerId, out var parsedGuid))
                {
                    return false;
                }
                userOwnerId = parsedGuid;
            }

            photo.TagUser = model.TagUser;
            photo.ImageUrl = model.ImageUrl;
            photo.Description = model.Description;
            photo.IsPrivate = model.IsPrivate;
            photo.UserOwnerId = userOwnerId;
            photo.UploadedAt = uploadedAt;
            photo.PhotosCategories = model.SelectedCategoryIds.Select(id => new PhotoCategory { CategoryId = id }).ToList();

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsPhotoOwnedByPhotographerAsync(string photoId, string userId)
        {
            Guid photoIdGuid = Guid.Empty;
            if (!IsGuidValid(photoId, ref photoIdGuid))
            {
                return false;
            }

            return await context.Photos
                .AnyAsync(p => p.Id == photoIdGuid
                               && !p.IsDeleted
                               && p.Photographer.UserId.ToString() == userId);
        }

        public async Task<DeleteViewModel?> GetPhotoDelete(Guid photoId)
        {
            Photo? photo = await context.Photos
                .Include(p => p.Photographer)
                .Include(p => p.PhotosCategories)
                .Where(p => p.Id == photoId && p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (photo == null)
            {
                return null;
            }

            return await context.Photos
                  .AsNoTracking()
                  .Where(p => p.Id == photoId && p.IsDeleted == false)
                  .Select(p => new DeleteViewModel()
                  {
                      Id = p.Id.ToString(),
                      TagUser = p.TagUser,
                      UploadedAt = p.UploadedAt.ToString(EntityDateFormat),
                      DeletedAt = null,
                      UserOwnerId = p.UserOwnerId.ToString() ?? String.Empty,
                      UserPhotographerId =  photo.Photographer.UserId.ToString(),
                      Owner = p.Owner.UserName
                  })
                  .FirstOrDefaultAsync();
        }

        public async Task<bool> DeletePhotoAsync(string photoId)
        {
            Photo? photoToDelete = await context.Photos
                .FirstOrDefaultAsync(p => p.Id.ToString() == photoId && !p.IsDeleted);

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
                  .Where(u => u.IsDeleted == false && !context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == adminRoleId))
                  .Select(u => new UserViewModel()
                  {
                      Id = u.Id.ToString(),
                      UserName = u.UserName ?? String.Empty
                  }).ToListAsync();

            return user;
        }

        public async Task<ICollection<AllPhotosViewModel>> GetAllPhotosAsync(ManageWithSearchFilterViewModel model)
        {
            IQueryable<Photo> allPhotosQuery = context
                .Photos
                .Where(p => p.IsDeleted == false)
                .AsQueryable();


            if (!String.IsNullOrWhiteSpace(model.SearchQuery))
            {
                allPhotosQuery = allPhotosQuery
                    .Where(p =>
                        (p.TagUser ?? string.Empty).ToLower().Contains(model.SearchQuery.ToLower()));
            }

            if (!String.IsNullOrWhiteSpace(model.CategoryFilter))
            {
                allPhotosQuery = allPhotosQuery.Where(p =>
                    p.PhotosCategories.Any(pc => pc.Category.Name.ToLower() == model.CategoryFilter.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(model.DateFilter))
            {
                Match rangeMatch = Regex.Match(model.DateFilter, DateRegexFormat);

                if (rangeMatch.Success)
                {
                    int startMonth = int.Parse(rangeMatch.Groups[1].Value);
                    int startYear = int.Parse(rangeMatch.Groups[2].Value);
                    int endMonth = int.Parse(rangeMatch.Groups[3].Value);
                    int endYear = int.Parse(rangeMatch.Groups[4].Value);

                    if (startYear < endYear)
                    {
                        allPhotosQuery = allPhotosQuery.Where(p =>
                            p.UploadedAt.Year >= startYear && p.UploadedAt.Year <= endYear);
                    }
                    else if (startYear == endYear)
                    {
                        allPhotosQuery = allPhotosQuery.Where(p =>
                            (p.UploadedAt.Year >= startYear && p.UploadedAt.Year <= endYear) &&
                            (p.UploadedAt.Month >= startMonth && p.UploadedAt.Month <= endMonth));
                    }

                }
                else if (int.TryParse(model.DateFilter, out int date))
                {
                    allPhotosQuery = allPhotosQuery.Where(m => m.UploadedAt.Year == date);
                }
            }

            if (model.CurrentPage.HasValue && model.EntitiesPerPage.HasValue)
            {
                allPhotosQuery = allPhotosQuery
                    .Skip(model.EntitiesPerPage.Value * (model.CurrentPage.Value - 1))
                    .Take(model.EntitiesPerPage.Value);
            }

            return await allPhotosQuery
                .OrderBy(p => p.UploadedAt)
                .Select(p => new AllPhotosViewModel()
                {
                    Id = p.Id.ToString(),
                    ImageUrl = p.ImageUrl,
                    IsPrivate = p.IsPrivate,
                    UserOwner = p.Owner,
                    Rating = p.Rating,
                    Photographer = p.Photographer,
                    Categories = p.PhotosCategories.Select(c => c.Category.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<int> GetPhotosCountByFilterAsync(GalleryWithSearchFilterViewModel inputModel)
        {
            GalleryWithSearchFilterViewModel inputModelCopy = new()
            {
                CurrentPage = null,
                EntitiesPerPage = null,
                SearchQuery = inputModel.SearchQuery,
                CategoryFilter = inputModel.CategoryFilter,
                DateFilter = inputModel.DateFilter
            };

            int photosCount = (await this.GetGalleryAsync(inputModelCopy)).Count();

            return photosCount;
        }

        public async Task<int> GetPrivatePhotosCountByFilterAsync(GalleryWithSearchFilterViewModel inputModel, Guid userId)
        {
            GalleryWithSearchFilterViewModel inputModelCopy = new()
            {
                CurrentPage = null,
                EntitiesPerPage = null,
                SearchQuery = inputModel.SearchQuery,
                CategoryFilter = inputModel.CategoryFilter,
                DateFilter = inputModel.DateFilter
            };

            var photos = await this.GetPrivateGalleryAsync(inputModel, userId);

            int photosCount = photos
                .Where(p => p.IsPrivate && userId.ToString() == p.UserOwnerId)
                .Count();

            return photosCount;
        }

        public async Task<int> GetManagePhotosCountByFilterAsync(ManageWithSearchFilterViewModel inputModel)
        {
            ManageWithSearchFilterViewModel inputModelCopy = new()
            {
                CurrentPage = null,
                EntitiesPerPage = null,
                SearchQuery = inputModel.SearchQuery,
                CategoryFilter = inputModel.CategoryFilter,
                DateFilter = inputModel.DateFilter
            };

            int photosCount = (await this.GetAllPhotosAsync(inputModelCopy)).Count();

            return photosCount;
        }


    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Admin.UserManagement;
using Photography.Core.ViewModels.Photographer;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly PhotographyDbContext context;


        public UserService(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole<Guid>> _roleManager, PhotographyDbContext _context)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            IEnumerable<ApplicationUser> allUsers = await userManager.Users
                .Where(u=>u.IsDeleted==false)
                .ToArrayAsync();

            ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                IEnumerable<string> roles = await userManager.GetRolesAsync(user);

                var photographer = await context
                    .Photographers.FirstOrDefaultAsync(p => p.UserId == user.Id);

                List<PhotographerViewModel> userPhotographer;

                if (photographer != null)
                {
                    userPhotographer = new List<PhotographerViewModel>
                    {
                        new PhotographerViewModel
                        {
                            Id = photographer.UserId.ToString(),
                            BrandName = photographer.BrandName
                        }
                    };
                }
                else
                {
                    userPhotographer = new List<PhotographerViewModel>();
                }

                allUsersViewModel.Add(new AllUsersViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Roles = roles,
                    Photographers = userPhotographer
                });
            }

            return allUsersViewModel;
        }


        public async Task<bool> UserExistByIdAsync(Guid userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            return user != null;
        }

        public async Task<bool> IsUserPhotographerAsync(Guid userId)
        {
            Photographer? user = await context
                .Photographers
                .FirstOrDefaultAsync(u => u.UserId == userId);

            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(Guid userId, string roleName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await userManager.IsInRoleAsync(user, roleName);

            if (!alreadyInRole)
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> RemoveUserRoleAsync(Guid userId, string roleName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            bool roleExists = await roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await userManager.IsInRoleAsync(user, roleName);

            if (alreadyInRole)
            {
                IdentityResult result = await userManager.RemoveFromRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            user.IsDeleted = true;

            // disconnect from photos
            List<Photo> photosToRemove = await context.Photos
                .Where(p => p.UserOwnerId == user.Id)
                .ToListAsync();
            foreach (var photo in photosToRemove)
            {
                photo.IsDeleted = true;
            }

            // disconect photos form categories
            List<PhotoCategory> photosCategoriesToRemove = await context
                .PhotosCategories
                .Where(pc => photosToRemove.Select(p => p.Id).Contains(pc.PhotoId))
                .ToListAsync();


            // disconnect from photoShoots
            List<PhotoShoot> photoShootsToRemove = await context.PhotoShoots
                .Where(ps => ps.Participants.Any(p => p.UserId == user.Id))
                .ToListAsync();
            foreach (var photoShoot in photoShootsToRemove)
            {
                photoShoot.IsDeleted = true;
            }

            // disconnect from ratings
            List<PhotoRating> photosRatingsToRemove = await context.PhotosRatings
                .Where(p => p.UserId == user.Id)
                .ToListAsync();
            context.PhotosRatings.RemoveRange(photosRatingsToRemove);

            // disconnect from favorites
            List<FavoritePhoto> favoritePhotoToRemove = await context.FavoritePhotos
                .Where(p => p.UserId == user.Id)
                .ToListAsync();
            context.FavoritePhotos.RemoveRange(favoritePhotoToRemove);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> MakeUserPhotographerAsync(Guid userId, string brandName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            bool isAlreadyPhotographer = await context.Photographers.AnyAsync(p => p.UserId == userId);

            if (isAlreadyPhotographer)
            {
                return false;
            }

            bool isBrandNameAlreadyInUse = await context.Photographers.AnyAsync(n => n.BrandName == brandName);

            if (isBrandNameAlreadyInUse)
            {
                return false;
            }

            var photographer = new Photographer
            {
                UserId = userId,
                BrandName = brandName,
                User = user
            };

            context.Photographers.Add(photographer);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveUserFromPhotographerAsync(Guid userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return false;
            }

            bool isPhotographer = await context.Photographers.AnyAsync(p => p.UserId == userId);

            if (!isPhotographer)
            {
                return false;
            }

            Photographer photographer = await context
                .Photographers.FirstAsync(p => p.UserId == userId);

            // disconnect from linked photoShoots
            List<PhotoShoot> photoShootsToRemove = context.PhotoShoots
                .Where(ps => ps.PhotographerId == photographer.Id)
                .ToList();

            // disconnect from linked photos
            List<Photo> photosToRemove = context.Photos
                .Where(p => p.PhotographerId == photographer.Id)
                .ToList();

            if (photosToRemove.Any())
            {
                foreach (var photo in photosToRemove)
                {
                    photo.Photographer = null;
                    await context.SaveChangesAsync();
                }
            }

            context.PhotoShoots.RemoveRange(photoShootsToRemove);
            context.Photographers.Remove(photographer);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

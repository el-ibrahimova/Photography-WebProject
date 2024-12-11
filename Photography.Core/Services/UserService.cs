namespace Photography.Core.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Interfaces;
    using ViewModels.Admin.UserManagement;
    using ViewModels.Photographer;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;

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
                .Where(u => u.IsDeleted == false)
                .ToArrayAsync();

            ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                IEnumerable<string> roles = await userManager.GetRolesAsync(user);

                var photographer = await context
                    .Photographers.FirstOrDefaultAsync(p => p.UserId.ToString().ToLower() == user.Id.ToString().ToLower());

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


        public async Task<bool> UserExistByIdAsync(string userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId);

            return user != null;
        }

        public async Task<bool> IsUserPhotographerAsync(string userId)
        {
            Photographer? user = await context
                .Photographers
                .FirstOrDefaultAsync(u => u.UserId.ToString().ToLower() == userId.ToLower());

            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(string userId, string roleName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId);

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

        public async Task<bool> RemoveUserRoleAsync(string userId, string roleName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId);

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

        public async Task<bool> DeleteUserAsync(string userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            user.IsDeleted = true;

            // disconnect from photos
            List<Photo> photosToRemove = await context.Photos
                .Where(p => p.UserOwnerId.ToString().ToLower() == user.Id.ToString().ToLower())
                .ToListAsync();
            foreach (var photo in photosToRemove)
            {
                photo.IsDeleted = true;
            }

            // disconect photos form categories
            List<PhotoCategory> relatedCategories = await context
                .PhotosCategories
                .Where(pc => photosToRemove.Select(p => p.Id).Contains(pc.PhotoId))
                .ToListAsync();
            context.RemoveRange(relatedCategories);


            // disconnect from photoShootParticipant
            List<PhotoShootParticipant> relatedParticipations = await context.PhotoShootParticipants
                .Where(ps => ps.UserId.ToString().ToLower() == userId.ToLower())
                .ToListAsync();
            context.PhotoShootParticipants.RemoveRange(relatedParticipations);

            // disconnect from ratings
            List<PhotoRating> relatedRatings = await context.PhotosRatings
                .Where(p => p.UserId.ToString().ToLower() == user.Id.ToString().ToLower())
                .ToListAsync();
            context.PhotosRatings.RemoveRange(relatedRatings);

            // disconnect from favorites
            List<FavoritePhoto> favoritePhotos = await context.FavoritePhotos
                .Where(p => p.UserId.ToString().ToLower() == user.Id.ToString().ToLower())
                .ToListAsync();
            context.FavoritePhotos.RemoveRange(favoritePhotos);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> MakeUserPhotographerAsync(string userId, string brandName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            bool isAlreadyPhotographer = await context.Photographers
                .AnyAsync(p => p.UserId.ToString().ToLower() == userId.ToLower());

            if (isAlreadyPhotographer)
            {
                return false;
            }

            bool isBrandNameAlreadyInUse = await context.Photographers
                .AnyAsync(n => n.BrandName == brandName);

            if (isBrandNameAlreadyInUse)
            {
                return false;
            }

            var photographer = new Photographer
            {
                UserId = Guid.Parse(userId),
                BrandName = brandName,
                User = user
            };

            context.Photographers.Add(photographer);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveUserFromPhotographerAsync(string userId)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            Photographer? photographer = await context.Photographers
                .FirstOrDefaultAsync(p => p.UserId.ToString().ToLower() == userId.ToLower());

            if (photographer == null)
            {
                return false;
            }

            // disconnect from linked photoShoots
            List<PhotoShoot> relatedPhotoShoots = await context.PhotoShoots
                .Where(ps => ps.PhotographerId.ToString().ToLower() == photographer.Id.ToString().ToLower())
                .ToListAsync();
            foreach (var photoShoot in relatedPhotoShoots)
            {
                photoShoot.IsDeleted = true;
            }

            // disconnect from linked photos
            List<Photo> relatedPhotos = await context.Photos
                .Where(p => p.PhotographerId.ToString().ToLower() == photographer.Id.ToString().ToLower())
                .ToListAsync();

            foreach (var photo in relatedPhotos)
            {
                var relatedCategories = await context.PhotosCategories
                    .Where(pc => pc.PhotoId == photo.Id)
                    .ToListAsync();

                context.PhotosCategories.RemoveRange(relatedCategories);

                photo.IsDeleted = true;
            }

            context.Photographers.Remove(photographer);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

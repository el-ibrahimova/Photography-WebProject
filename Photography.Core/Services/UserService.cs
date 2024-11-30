using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                .ToArrayAsync();

            ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                IEnumerable<string> roles = await this.userManager.GetRolesAsync(user);

                var photographer = await context.Photographers.FirstOrDefaultAsync(p => p.UserId == user.Id);

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
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId.ToString());

            return user != null;
        }

        public async Task<bool> IsUserPhotographerAsync(Guid userId)
        {
           Photographer? user = await this.context.Photographers.FirstOrDefaultAsync(u=>u.UserId==userId);

            return user != null;
        }

        public async Task<bool> AssignUserToRoleAsync(Guid userId, string roleName)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(userId.ToString());

            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);

            if (!alreadyInRole)
            {
                IdentityResult result = await this.userManager.AddToRoleAsync(user, roleName);

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

            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);

            if (user == null || !roleExists)
            {
                return false;
            }

            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);

            if (alreadyInRole)
            {
                IdentityResult result = await this.userManager.RemoveFromRoleAsync(user, roleName);

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

            IdentityResult? result = await this.userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return false;
            }

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

            if (user == null )
            {
                return false;
            }

            bool isPhotographer = await context.Photographers.AnyAsync(p=>p.UserId == userId);

            if (!isPhotographer)
            {
                return false;
            }

            Photographer photographer = await context
                .Photographers.FirstAsync(p => p.UserId == userId);

            context.Photographers.Remove(photographer);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

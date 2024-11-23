﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Admin.UserManagement;
using Photography.Infrastructure.Data.Models;

namespace Photography.Core.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole<Guid>> _roleManager)
       {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            IEnumerable<ApplicationUser> allUsers = await userManager.Users
                .ToArrayAsync();

            ICollection<AllUsersViewModel> allUsersViewModel = new List<AllUsersViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                IEnumerable<string> roles = await this.userManager.GetRolesAsync(user);

                allUsersViewModel.Add(new AllUsersViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Roles = roles
                });
            }

            return allUsersViewModel;
        }

        public async Task<bool> UserExistByIdAsync(Guid userId)
        {
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId.ToString());

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

            IdentityResult result = await this.userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}

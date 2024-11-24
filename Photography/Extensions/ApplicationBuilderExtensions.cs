using Photography.Infrastructure.Data;

namespace Photography.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Infrastructure.Data.Models;
    using static Common.ApplicationConstants;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email, string username, string password)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateAsyncScope();

            IServiceProvider serviceProvider = serviceScope.ServiceProvider;

            RoleManager<IdentityRole<Guid>>? roleManager = serviceProvider.GetService<RoleManager<IdentityRole<Guid>>>();

            IUserStore<ApplicationUser>? userStore = serviceProvider.GetService<IUserStore<ApplicationUser>>();

            UserManager<ApplicationUser>? userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            if (roleManager == null)
            {
                throw new ArgumentNullException(
                    nameof(roleManager), $"Service for {typeof(RoleManager<IdentityRole<Guid>>)} cannot be obtained!");
            }

            if (userStore == null)
            {
                throw new ArgumentNullException(
                    nameof(userStore), $"Service for {typeof(IUserStore<ApplicationUser>)} cannot be obtained!");
            }


            if (userManager == null)
            {
                throw new ArgumentNullException(
                    nameof(userManager), $"Service for {typeof(UserManager<ApplicationUser>)} cannot be obtained!");
            }

            
            Task.Run(async () =>
            {
                bool roleExists = await roleManager.RoleExistsAsync(AdminRoleName);

                IdentityRole<Guid>? adminRole = null;
                if (!roleExists)
                {
                    adminRole = new IdentityRole<Guid>(AdminRoleName);

                    IdentityResult result = await roleManager.CreateAsync(adminRole);

                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException($"Възникна грешка по време на създаването на {AdminRoleName} роля");
                    }
                }
                else
                {
                    adminRole = await roleManager.FindByNameAsync(AdminRoleName);
                }

                ApplicationUser? adminUser = await userManager.FindByEmailAsync(email);
                if (adminUser == null)
                {
                    adminUser = await CreateAdminUserAsync(email, username, password, userStore, userManager);
                }

                if (await userManager.IsInRoleAsync(adminUser, AdminRoleName))
                {
                    return app;
                }

                IdentityResult userResult = await userManager.AddToRoleAsync(adminUser, AdminRoleName);

                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Възникна грешка при добавянето на ${username} към ролята на {adminRole}");
                }

                return app;
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }

        private static async Task<ApplicationUser> CreateAdminUserAsync(string email, string username, string password, IUserStore<ApplicationUser> userStore, UserManager<ApplicationUser> userManager)
        {
            //the same form from Register

            ApplicationUser applicationUser = new ApplicationUser()
            {
                Email = email
            };

            await userStore.SetUserNameAsync(applicationUser, username, CancellationToken.None);
            IdentityResult result = await userManager.CreateAsync(applicationUser, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Възникна грешка при регистрирането на потребител с роля {AdminRoleName}");
            }

            return applicationUser;
        }
    }
}

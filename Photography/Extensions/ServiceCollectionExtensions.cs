using Photography.Core.Interfaces;
using Photography.Core.Services;

namespace Photography.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBaseService, BaseService>();
            serviceCollection.AddScoped<IPhotoService, PhotoService>();
            serviceCollection.AddScoped<IGalleryService, GalleryService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IPhotoShootService, PhotoShootService>();
            serviceCollection.AddScoped<IUserService, UserService >();
        }
    }
}

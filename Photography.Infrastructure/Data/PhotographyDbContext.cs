using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Photography.Infrastructure.Data.Configurations;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data
{
    public class PhotographyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PhotographyDbContext()
        {

        }
        public PhotographyDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<FavoritePhoto> FavoritePhotos { get; set; } = null!;
        public DbSet<PhotoCategory> PhotosCategories { get; set; } = null!;
        public DbSet<PhotoRating> PhotosRatings { get; set; } = null!;
        public DbSet<Photographer> Photographers { get; set; } = null!;
        public DbSet<PhotoShoot> PhotoShoots { get; set; } = null!;
        public DbSet<PhotoShootParticipant> PhotoShootParticipants { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("DefaultConnection");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PhotographerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new PhotoCategoryConfiguration());
            builder.ApplyConfiguration(new PhotoRatingConfiguration());
            builder.ApplyConfiguration(new FavoritePhotoConfiguration());
            builder.ApplyConfiguration(new PhotoShootConfiguration());
            builder.ApplyConfiguration(new PhotoShootParticipantConfiguration());

            base.OnModelCreating(builder);
        }
    }
}

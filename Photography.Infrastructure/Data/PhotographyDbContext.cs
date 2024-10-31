using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Photography.Infrastructure.Data.Configurations;
using Photography.Infrastructure.Data.Models;

namespace Photography.Data
{
    public class PhotographyDbContext : IdentityDbContext
    {
        public PhotographyDbContext(DbContextOptions<PhotographyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<FavoritePhoto> FavoritePhotos { get; set; }= null!;
        public DbSet<Offer> Offers { get; set; } = null!;
        public DbSet<OfferType> OfferTypes { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderPhoto> OrderPhotos { get; set; } = null!;
        public DbSet<PhotoCategory> PhotosCategories { get; set; } = null!;

        public DbSet<PhotoRating> PhotosRatings { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new FavoritePhotoConfiguration());
            builder.ApplyConfiguration(new OfferTypeConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new PhotoConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PhotoCategoryConfiguration());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoCategoryConfiguration:IEntityTypeConfiguration<PhotoCategory>
    {
        public void Configure(EntityTypeBuilder<PhotoCategory> builder)
        {
            builder.HasKey(pc => new { pc.CategoryId, pc.PhotoId });

            builder.HasOne(pc => pc.Photo).WithMany(p => p.PhotosCategories).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(pc => pc.Category).WithMany(c=> c.PhotosCategories).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

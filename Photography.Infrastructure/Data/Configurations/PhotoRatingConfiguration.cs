using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoRatingConfiguration:IEntityTypeConfiguration<PhotoRating>
    {
        public void Configure(EntityTypeBuilder<PhotoRating> builder)
        {
            builder.HasKey(pr => new { pr.UserId, pr.PhotoId });

            builder.HasOne(pr => pr.User)
                .WithMany(pr => pr.PhotosRatings)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pr => pr.Photo)
                .WithMany(pr => pr.PhotosRatings)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

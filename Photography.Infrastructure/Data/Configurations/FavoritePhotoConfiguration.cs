﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class FavoritePhotoConfiguration:IEntityTypeConfiguration<FavoritePhoto>
    {
        public void Configure(EntityTypeBuilder<FavoritePhoto> builder)
        {
            builder.HasKey(fp => new { fp.PhotoId, fp.UserId });

            builder.HasOne(fp => fp.Photo).WithMany(fp => fp.FavoritePhotos).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(fp => fp.User).WithMany(fp => fp.FavoritePhotos).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

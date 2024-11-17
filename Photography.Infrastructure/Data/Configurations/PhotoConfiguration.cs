﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoConfiguration:IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(p => p.IsDeleted)
                .IsRequired(true)
                .HasDefaultValue(false);
            builder.Property(p => p.Rating)
                .HasDefaultValue(0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoShootConfiguration:IEntityTypeConfiguration<PhotoShoot>
    {
        public void Configure(EntityTypeBuilder<PhotoShoot> builder)
        {
            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}

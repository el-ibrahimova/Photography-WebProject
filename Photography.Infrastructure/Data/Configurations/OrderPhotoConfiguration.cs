using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class OrderPhotoConfiguration:IEntityTypeConfiguration<OrderPhoto>
    {
        public void Configure(EntityTypeBuilder<OrderPhoto> builder)
        {
            builder.HasKey(op => new { op.OrderId, op.PhotoId, op.OfferId });

            builder.Property(o => o.Count).HasDefaultValue(1);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class OfferTypeConfiguration:IEntityTypeConfiguration<OfferType>
    {
        public void Configure(EntityTypeBuilder<OfferType> builder)
        {
            builder.Property(p => p.Price)
                .HasPrecision(10, 2);
        }
    }
}

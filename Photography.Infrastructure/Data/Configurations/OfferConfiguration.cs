using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class OfferConfiguration:IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(o => o.Price).HasPrecision(18, 2);
            builder.HasData(SeedOffers());
        }

        private IEnumerable<Offer> SeedOffers()
        {
            IEnumerable<Offer> offers = new List<Offer>()
            {
                new Offer() { Name = "Печат на снимка в размер 9х13", Price = 0.40m},
                new Offer() { Name = "Печат на снимка в размер 10x15", Price = 0.45m},
                new Offer() { Name = "Печат на снимка в размер 13x18", Price = 1.20m},
                new Offer() { Name = "Печат на снимка в размер А4", Price = 2.00m},
                new Offer() { Name = "Печат на снимка върху чаша", Price = 12.00m},
                new Offer() { Name = "Печат на снимка върху тениска",Price = 18m}
            };

            return offers;
        }
    }
}

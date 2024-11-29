using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    internal class PhotographerConfiguration : IEntityTypeConfiguration<Photographer>
    {
        public void Configure(EntityTypeBuilder<Photographer> builder)
        {

            builder.HasData(SeedPhotographers());
        }

        public IEnumerable<Photographer> SeedPhotographers()
        {
            IEnumerable<Photographer> photographers = new List<Photographer>()
            {
                new Photographer()
                {
                       Id = Guid.Parse("CD32306A-B068-4473-AE9D-6FD1BFF6E8A2"),
                       BrandName = "NIES",
                       UserId = Guid.Parse("04C70E70-5CF9-4E8A-A694-5C7C8D730A8F")
                }
            };

            return photographers;
        }
    }
}

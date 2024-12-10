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
                       Id = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4"),
                       BrandName = "NIES",
                       UserId = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841")
                }
            };

            return photographers;
        }
    }
}

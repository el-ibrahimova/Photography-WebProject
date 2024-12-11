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
                },

                new Photographer()
                {
                    Id = Guid.Parse("01A0E6F6-DA36-4634-9533-E6BD4E861C11"),
                    BrandName = "MIKI",
                    UserId = Guid.Parse("5DBF7705-08FA-472D-BF9C-1FAEAA220749")
                }
            };

            return photographers;
        }
    }
}

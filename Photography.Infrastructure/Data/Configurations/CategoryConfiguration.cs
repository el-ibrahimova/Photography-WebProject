using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.HasData(SeedCategories());
        }

        private IEnumerable<Category> SeedCategories()
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category() { Id = Guid.Parse("5D56E870-0080-4609-B189-94282AE97F31"), Name = "Животни", IsDeleted = false},
                new Category() { Id = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581"), Name = "Природа", IsDeleted = false },
                new Category() { Id = Guid.Parse("BCC254E8-2534-4791-90E2-D17C03122886"),  Name = "Храна и напитки", IsDeleted = false},
                new Category() { Id = Guid.Parse("AA25251B-6DDC-438B-B5F0-28B3341731E3"), Name = "Семейна фотография", IsDeleted = false },
                new Category() { Id = Guid.Parse("8E1654CF-F730-41C7-92C2-0E280A94E7CE"),  Name = "Спорт", IsDeleted = false},
                new Category() { Id = Guid.Parse("13A08262-6477-40F9-8DB7-D6EBD4178E47"),Name = "Архитектура", IsDeleted = false},
                new Category() { Id = Guid.Parse("E5AEDD38-0DC5-49E4-B51A-ACF63FD991A8"),  Name = "Пътуваня и дестинации",IsDeleted = false },
                new Category() { Id = Guid.Parse("C7347C35-EFFB-4CD6-9334-1348EC5D635B"), Name = "Черно-бяла фотография", IsDeleted = false},
                new Category() { Id = Guid.Parse("C7E699D1-FC73-459B-8F0F-11B7C4E101B5"),Name = "Мода", IsDeleted = false },
                new Category() { Id = Guid.Parse("C1F05508-2B56-46D8-86F9-027F5AAEE67A"), Name = "Пейзажи",IsDeleted = false },
                new Category() { Id = Guid.Parse("A5B3D93C-96D1-41AB-8D07-4CBF7754656F"),  Name = "Други",IsDeleted = false },
            };

            return categories;
        }
    }
}

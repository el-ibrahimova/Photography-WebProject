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
                new Category() { Name = "Животни", IsDeleted = false},
                new Category() { Name = "Природа", IsDeleted = false },
                new Category() { Name = "Храна и напитки", IsDeleted = false},
                new Category() { Name = "Семейна фотография", IsDeleted = false },
                new Category() { Name = "Спорт", IsDeleted = false},
                new Category() { Name = "Архитектура", IsDeleted = false},
                new Category() { Name = "Пътуваня и дестинации",IsDeleted = false },
                new Category() { Name = "Черно-бяла фотография", IsDeleted = false},
                new Category() { Name = "Мода", IsDeleted = false },
                new Category() { Name = "Пейзажи",IsDeleted = false }
            };

            return categories;
        }
    }
}

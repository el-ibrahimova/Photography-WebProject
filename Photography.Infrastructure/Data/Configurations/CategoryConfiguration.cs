using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private IEnumerable<Category> SeedCategories()
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category() { Name = "Животни", },
                new Category() { Name = "Природа", },
                new Category() { Name = "Храна и напитки", },
                new Category() { Name = "Семейна фотография", },
                new Category() { Name = "Спорт", },
                new Category() { Name = "Архитектура", },
                new Category() { Name = "Пътуваня и дестинации", },
                new Category() { Name = "Черно-бяла фотография", },
                new Category() { Name = "Мода", },
                new Category() { Name = "Пейзажи", }
            };

            return categories;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            ICollection<Category> categories = SeedCategories();
            builder.HasData(categories);
        }

        private ICollection<Category> SeedCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category() {Id=1, Name = "Животни", },
                new Category() {Id=2, Name = "Природа", },
                new Category() {Id=3, Name = "Храна и напитки", },
                new Category() {Id=4, Name = "Семейна фотография", },
                new Category() {Id=5, Name = "Спорт", },
                new Category() {Id=6, Name = "Архитектура", },
                new Category() {Id=7, Name = "Пътуваня и дестинации", },
                new Category() {Id=8, Name = "Черно-бяла фотография", },
                new Category() {Id=9, Name = "Мода", },
                new Category() {Id=10, Name = "Пейзажи", }
            };

            return categories;
        }

    }
}

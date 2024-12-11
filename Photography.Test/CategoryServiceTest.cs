using Photography.Core.Interfaces;

namespace Photography.Test
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Core.Services;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Core.ViewModels.Category;

    [TestFixture]
    public class CategoryServiceTests
    {
        private PhotographyDbContext context;
        private ICategoryService categoryService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<PhotographyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new PhotographyDbContext(options);
            categoryService = new CategoryService(context, null); // `null` for IPhotoService as it's not used in these tests
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        //[Test]
        //public async Task AddCategoryAsync_ShouldAddCategory()
        //{
        //    // Arrange
        //    var model = new AddCategoryViewModel { Name = "Test Category" };

        //    // Act
        //    var result = await categoryService.AddCategoryAsync(model);

        //    // Assert
        //    Assert.IsTrue(result);
        //    Assert.That(context.Categories.Count(), Is.EqualTo(1));
        //    Assert.That(context.Categories.First().Name, Is.EqualTo("Test Category"));
        //}

        //[Test]
        //public async Task GetCategoryToEditAsync_ShouldReturnCategory()
        //{
        //    // Arrange
        //    var category = new Category { Name = "Edit Test", IsDeleted = false };
        //    await context.Categories.AddAsync(category);
        //    await context.SaveChangesAsync();

        //    // Act
        //    var result = await categoryService.GetCategoryToEditAsync(category.Id.ToString());

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.That(result.Id, Is.EqualTo(category.Id.ToString()));
        //    Assert.That(result.Name, Is.EqualTo("Edit Test"));
        //}


        [Test]
        public async Task EditCategoryAsync_ShouldEditCategory()
        {
            // Arrange
            var category = new Category { Name = "Old Name", IsDeleted = false };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            var model = new CategoryFormViewModel
            {
                Id = category.Id.ToString(),
                Name = "New Name"
            };

            // Act
            var result = await categoryService.EditCategoryAsync(model);

            // Assert
            Assert.IsTrue(result);
            Assert.That(context.Categories.First().Name, Is.EqualTo("New Name"));
        }

        //[Test]
        //public async Task DeleteCategoryAsync_ShouldMarkCategoryAsDeleted()
        //{
        //    // Arrange
        //    var category = new Category { Name = "To Delete", IsDeleted = false };
        //    await context.Categories.AddAsync(category);
        //    await context.SaveChangesAsync();

        //    // Act
        //    var result = await categoryService.DeleteCategoryAsync(category.Id.ToString());

        //    // Assert
        //    Assert.IsTrue(result);
        //    Assert.IsTrue(context.Categories.First().IsDeleted);
        //}

        //[Test]
        //public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
        //{
        //    // Arrange
        //    await context.Categories.AddRangeAsync(
        //        new Category { Name = "Category 1", IsDeleted = false },
        //        new Category { Name = "Category 2", IsDeleted = false }
        //    );
        //    await context.SaveChangesAsync();

        //    // Act
        //    var result = await categoryService.GetAllCategoriesAsync();

        //    // Assert
        //    Assert.AreEqual(2, result.Count);
        //    Assert.IsTrue(result.Any(c => c.Name == "Category 1"));
        //    Assert.IsTrue(result.Any(c => c.Name == "Category 2"));
        //}
    }
}


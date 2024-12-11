using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Test
{
    [TestFixture]   
    public class PhotographerServiceTest
    {
        private PhotographyDbContext context;
        private IPhotographerService photographerService;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<PhotographyDbContext>()
                .UseInMemoryDatabase(databaseName: "PhotographyInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            context = new PhotographyDbContext(options);
            photographerService = new PhotographerService(context);
        }

        [TearDown]
        public async Task Teardown()
        {
           await context.DisposeAsync();
        }

        [Test]
        public async Task ExistsByIdAsync_Returns_True_When_Photographer_Exists()
        {
            // Arrange
            var user = new ApplicationUser { Id = Guid.NewGuid(), UserName = "user1", Email = "user1@example.com", IsDeleted = false };
            var photographer = new Photographer { UserId = user.Id, BrandName = "Brand1" };

            await context.Users.AddAsync(user);
            await context.Photographers.AddAsync(photographer);
            await context.SaveChangesAsync();

            // Act
            var result = await photographerService.ExistsByIdAsync(user.Id.ToString());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsync_Returns_False_When_Photographer_Does_Not_Exist()
        {
            // Act
            var result = await photographerService.ExistsByIdAsync(Guid.NewGuid().ToString());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CreateAsync_Returns_True_When_Creating_New_Photographer()
        {
            // Arrange
            var user = new ApplicationUser { Id = Guid.NewGuid(), UserName = "user1", Email = "user1@example.com", IsDeleted = false };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            // Act
            var result = await photographerService.CreateAsync(user.Id.ToString(), "NewBrand");

            // Assert
            Assert.IsTrue(result);

            var photographer = await context.Photographers.FirstAsync(p => p.UserId == user.Id);
            Assert.IsNotNull(photographer);
            Assert.That(photographer.BrandName, Is.EqualTo("NewBrand"));
        }

        [Test]
        public async Task CreateAsync_Returns_False_When_User_Does_Not_Exist()
        {
            // Act
            var result = await photographerService.CreateAsync(Guid.NewGuid().ToString(), "Brand1");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task UserWithBrandNameExistAsync_Returns_True_When_BrandName_Exists()
        {
            // Arrange
            var user = new ApplicationUser { Id = Guid.NewGuid(), UserName = "user1", Email = "user1@example.com", IsDeleted = false };
            var photographer = new Photographer { UserId = user.Id, BrandName = "Brand1" };

            await context.Users.AddAsync(user);
            await context.Photographers.AddAsync(photographer);
            await context.SaveChangesAsync();

            // Act
            var result = await photographerService.UserWithBrandNameExistAsync("Brand1");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UserWithBrandNameExistAsync_Returns_False_When_BrandName_Does_Not_Exist()
        {
            // Act
            var result = await photographerService.UserWithBrandNameExistAsync("No Brand Exist");

            // Assert
            Assert.IsFalse(result);
        }
    }
}

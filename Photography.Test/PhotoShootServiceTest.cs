using Microsoft.EntityFrameworkCore;
using Moq;
using Photography.Core.Services;
using Photography.Core.ViewModels.PhotoShoot;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Test
{
    [TestFixture]
    public class PhotoShootServiceTest
    {
        private Mock<PhotographyDbContext> contextMock;
        private PhotoShootService photoShootService;

        [SetUp]
        public void Setup()
        {
            contextMock = new Mock<PhotographyDbContext>();
            photoShootService = new PhotoShootService(contextMock.Object);
        }

        [Test]
        public async Task AddPhotoShootAsync_ValidData_ReturnsTrue()
        {
            // Arrange
            var photoShootViewModel = new AddPhotoShootViewModel
            {
                Name = "Wedding",
                ImageUrl1 = "image1.jpg",
                ImageUrl2 = "image2.jpg",
                ImageUrl3 = "image3.jpg",
                Description = "Wedding photoShoot",
                PhotographerId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd")
            };

            var mockDbSet = new Mock<DbSet<PhotoShoot>>();
            contextMock.Setup(c => c.PhotoShoots).Returns(mockDbSet.Object);

            // Act
            var result = await photoShootService.AddPhotoShootAsync(photoShootViewModel);

            // Assert
            Assert.IsTrue(result);
            mockDbSet.Verify(m => m.AddAsync(It.IsAny<PhotoShoot>(), default), Times.Once);
            contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

    }

    
}

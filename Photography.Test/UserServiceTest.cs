using Microsoft.AspNetCore.Identity;
using Moq;
using Photography.Core.Services;
using Photography.Infrastructure.Data;
using Photography.Infrastructure.Data.Models;

namespace Photography.Test
{
    [TestFixture]
    public class UserServiceTest
    {
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock;
        private Mock<PhotographyDbContext> contextMock;
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            userManagerMock = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

            roleManagerMock = new Mock<RoleManager<IdentityRole<Guid>>>(
                new Mock<IRoleStore<IdentityRole<Guid>>>().Object,
                null, null, null, null);

            contextMock = new Mock<PhotographyDbContext>();

            userService = new UserService(userManagerMock.Object, roleManagerMock.Object, contextMock.Object);
        }

        [Test]
        public async Task UserExistByIdAsync_ReturnsTrueIfUserExists()
        {
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = Guid.Parse(userId), Email = "user1@test.com" };

            userManagerMock.Setup(um => um.FindByIdAsync(userId))
                .ReturnsAsync(user);

            // Act
            var result = await userService.UserExistByIdAsync(userId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task AssignUserToRoleAsync_AddsRoleToUser()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser { Id = Guid.Parse(userId), Email = "user1@test.com" };
            var roleName = "Admin";

            userManagerMock.Setup(um => um.FindByIdAsync(userId))
                .ReturnsAsync(user);

            roleManagerMock.Setup(rm => rm.RoleExistsAsync(roleName))
                .ReturnsAsync(true);

            userManagerMock.Setup(um => um.IsInRoleAsync(user, roleName))
                .ReturnsAsync(false);

            userManagerMock.Setup(um => um.AddToRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await userService.AssignUserToRoleAsync(userId, roleName);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task AssignUserToRoleAsync_ReturnsFalseIfRoleDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var roleName = "NonExistentRole";

            userManagerMock.Setup(um => um.FindByIdAsync(userId))
                .ReturnsAsync(new ApplicationUser { Id = Guid.Parse(userId) });

            roleManagerMock.Setup(rm => rm.RoleExistsAsync(roleName))
                .ReturnsAsync(false);

            // Act
            var result = await userService.AssignUserToRoleAsync(userId, roleName);

            // Assert
            Assert.False(result);
        }
    }
}

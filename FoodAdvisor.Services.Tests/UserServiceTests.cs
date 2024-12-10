using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<RoleManager<IdentityRole<Guid>>> roleManagerMock;
        private Mock<IManagerService> managerServiceMock;


        [SetUp]
        public void SetUp()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            var roleStoreMock = new Mock<IRoleStore<IdentityRole<Guid>>>();
            roleManagerMock = new Mock<RoleManager<IdentityRole<Guid>>>(roleStoreMock.Object, null, null, null, null);

            managerServiceMock = new Mock<IManagerService>();
        }

        [Test]
        public async Task DeleteUserAsync_UserExists_ReturnsTrue()
        {
            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId };
            userManagerMock.Setup(u => u.FindByIdAsync(userId.ToString())).ReturnsAsync(user);
            userManagerMock.Setup(u => u.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);

            var result = await userService.DeleteUserAsync(userId);

            Assert.IsTrue(result);
            userManagerMock.Verify(u => u.DeleteAsync(user), Times.Once);
        }
        [Test]
        public async Task DeleteUserAsync_UserDoesNotExist_ReturnsFalse()
        {
            var userId = Guid.NewGuid();
            userManagerMock.Setup(u => u.FindByIdAsync(userId.ToString())).ReturnsAsync((ApplicationUser)null);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);

            var result = await userService.DeleteUserAsync(userId);

            Assert.IsFalse(result);
            userManagerMock.Verify(u => u.DeleteAsync(It.IsAny<ApplicationUser>()), Times.Never);
        }

        [Test]
        public async Task DeleteUserAsync_DeleteFails_ReturnsFalse()
        {
            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId };
            userManagerMock.Setup(u => u.FindByIdAsync(userId.ToString())).ReturnsAsync(user);
            userManagerMock.Setup(u => u.DeleteAsync(user)).ReturnsAsync(IdentityResult.Failed());

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);

            var result = await userService.DeleteUserAsync(userId);

            Assert.IsFalse(result);
            userManagerMock.Verify(u => u.DeleteAsync(user), Times.Once);
        }
        [Test]
        public async Task UpdateRoleAsync_UserAndRoleExist_ReturnsTrue()
        {
            var userId = Guid.NewGuid();
            var roleName = "Admin";
            var user = new ApplicationUser { Id = userId };

            userManagerMock
                .Setup(u => u.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);
            roleManagerMock
                .Setup(r => r.RoleExistsAsync(roleName))
                .ReturnsAsync(true);
            userManagerMock
                .Setup(u => u.IsInRoleAsync(user, roleName))
                .ReturnsAsync(false);
            userManagerMock
                .Setup(u => u.AddToRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Success);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);
            var result = await userService.UpdateRoleAsync(userId, roleName);


            Assert.IsTrue(result);
            userManagerMock.Verify(u => u.AddToRoleAsync(user, roleName), Times.Once);
        }

        [Test]
        public async Task RemoveRoleAsync_UserNotInRole_ReturnsTrue()
        {
            var userId = Guid.NewGuid();
            var roleName = "Admin";
            var user = new ApplicationUser { Id = userId };

            userManagerMock
                .Setup(u => u.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);
            roleManagerMock
                .Setup(r => r.RoleExistsAsync(roleName))
                .ReturnsAsync(true);
            userManagerMock
                .Setup(u => u.IsInRoleAsync(user, roleName))
                .ReturnsAsync(false);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);
            var result = await userService.RemoveRoleAsync(userId, roleName);

            Assert.IsTrue(result);
            userManagerMock.Verify(u => u.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public async Task MakeManagerAsync_UserNotAlreadyManager_ReturnsTrue()
        {
            var userId = Guid.NewGuid().ToString();
            var phoneNumber = "123456789";
            var address = "Some Address";
            var user = new ApplicationUser { Id = Guid.Parse(userId) };

            userManagerMock
                .Setup(u => u.FindByIdAsync(userId))
                .ReturnsAsync(user);
            managerServiceMock
                .Setup(m => m.IsUserManagerAsync(userId))
                .ReturnsAsync(false);
            managerServiceMock
                .Setup(m => m.AddManagerAsync(Guid.Parse(userId), phoneNumber, address))
                .Returns(Task.CompletedTask);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);

            var result = await userService.MakeManagerAsync(userId, phoneNumber, address);

            Assert.IsTrue(result);
            managerServiceMock.Verify(m => m.AddManagerAsync(Guid.Parse(userId), phoneNumber, address), Times.Once);
        }
        [Test]
        public async Task RemoveManagerAsync_ManagerExists_ReturnsTrue()
        {
            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId };

            userManagerMock
                .Setup(u => u.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);
            managerServiceMock
                .Setup(m => m.IsUserManagerAsync(userId.ToString()))
                .ReturnsAsync(true);
            managerServiceMock
                .Setup(m => m.RemoveManagerAsync(userId))
                .ReturnsAsync(true);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);

            var result = await userService.RemoveManagerAsync(userId);

            Assert.IsTrue(result);
            managerServiceMock.Verify(m => m.RemoveManagerAsync(userId), Times.Once);
        }

        [Test]
        public async Task UpdateRoleAsync_UserOrRoleDoesNotExist_ReturnsFalse()
        {
            var userId = Guid.NewGuid();
            var roleName = "NonExistentRole";

            userManagerMock
                .Setup(u => u.FindByIdAsync(userId.ToString()))
                .ReturnsAsync((ApplicationUser)null);
            roleManagerMock
                .Setup(r => r.RoleExistsAsync(roleName))
                .ReturnsAsync(false);

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);

            var result = await userService.UpdateRoleAsync(userId, roleName);

            Assert.IsFalse(result);
            userManagerMock.Verify(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public async Task GetAllUsersAsync_ReturnsCorrectUserViewModels()
        {
            var users = new List<ApplicationUser>
                {
                    new ApplicationUser 
                    { 
                        Id = Guid.NewGuid(), 
                        Email = "user1@test.com",
                        UserName = "User1"
                    },
                    new ApplicationUser 
                    { Id = Guid.NewGuid(), 
                        Email = "user2@test.com",
                        UserName = "User2"
                    }
                };

            userManagerMock
                .Setup(u => u.Users).Returns(users.AsQueryable()
                .BuildMock());
            managerServiceMock
                .Setup(m => m.IsUserManagerAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            foreach (var user in users)
            {
                userManagerMock
                    .Setup(u => u.GetRolesAsync(user))
                    .ReturnsAsync(new List<string>());
            }

            IUserService userService = new UserService(userManagerMock.Object, roleManagerMock.Object, managerServiceMock.Object);
            var result = await userService.GetAllUsersAsync();

            Assert.That(result.Count(), Is.EqualTo(users.Count));
            Assert.That(result.First().Email, Is.EqualTo(users[0].Email));
            Assert.That(result.Last().Email, Is.EqualTo(users[1].Email));

            foreach (var user in users)
            {
                managerServiceMock
                    .Verify(m => m.IsUserManagerAsync(user.Id.ToString()), Times.Once);
                userManagerMock
                    .Verify(u => u.GetRolesAsync(user), Times.Once);
            }
        }
    }

}


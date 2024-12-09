using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	public class ManagerServiceTests
	{
		private Mock<IRepository<Manager, Guid>> managerRepository;
	

		[SetUp]
		public void Setup()
		{
			this.managerRepository = new Mock<IRepository<Manager, Guid>>();
		}
		[Test]
		public async Task IsUserManagerAsync_ValidUserId_ReturnsTrue()
		{
			var userId = Guid.NewGuid().ToString().ToLower();
			managerRepository
				.Setup(mr => mr.GetAllAttached())
				.Returns(new List<Manager>
				{
				new Manager { UserId = Guid.Parse(userId) }
				}.AsQueryable().BuildMockDbSet().Object);

			 IManagerService managerService = new ManagerService(managerRepository.Object);

			var result = await managerService.IsUserManagerAsync(userId);

			Assert.IsTrue(result);
			managerRepository.Verify(mr => mr.GetAllAttached(), Times.Once);
		}

		[Test]
		public async Task IsUserManagerAsync_InvalidUserId_ReturnsFalse()
		{
			
			var userId = Guid.NewGuid().ToString().ToLower();
			managerRepository
				.Setup(mr => mr.GetAllAttached())
				.Returns(new List<Manager>().AsQueryable().BuildMockDbSet().Object);

			IManagerService managerService = new ManagerService(managerRepository.Object);

			var result = await managerService.IsUserManagerAsync(userId);

			// Assert
			Assert.IsFalse(result);
			managerRepository.Verify(mr => mr.GetAllAttached(), Times.Once);
		}

		[Test]
		public async Task IsUserManagerAsync_NullOrEmptyUserId_ReturnsFalse()
		{
			string userId = null;

			IManagerService managerService = new ManagerService(managerRepository.Object);

			var result = await managerService.IsUserManagerAsync(userId);

			// Assert
			Assert.IsFalse(result);
			managerRepository.Verify(mr => mr.GetAllAttached(), Times.Never);
		}
		[Test]
		public async Task AddManagerAsync_ShouldCallAddAsyncWithCorrectManager()
		{
			var testUserId = Guid.NewGuid();
			var testPhoneNumber = "123-456-7890";
			var testAddress = "123 Test Street";

			IManagerService managerService = new ManagerService(managerRepository.Object);
			await managerService.AddManagerAsync(testUserId, testPhoneNumber, testAddress);

			managerRepository.Verify(
				repo => repo.AddAsync(It.Is<Manager>(m =>
					m.UserId == testUserId &&
					m.WorkPhoneNumber == testPhoneNumber &&
					m.Address == testAddress)),
				Times.Once);
		}
		[Test]
		public async Task RemoveManagerAsync_ShouldReturnFalse_WhenManagerNotFound()
		{
			var testUserId = Guid.NewGuid();

			managerRepository
				.Setup(repo => repo.FirstorDefaultAsync(It.IsAny<Expression<Func<Manager, bool>>>()))
				.ReturnsAsync((Manager)null);
			IManagerService managerService = new ManagerService(managerRepository.Object);

			var result = await managerService.RemoveManagerAsync(testUserId);

			Assert.IsFalse(result);
			managerRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>()), Times.Never); 
		}
		public async Task RemoveManagerAsyncShouldReturnFalseWhenDeleteFails()
		{
			var testUserId = Guid.NewGuid();
			var manager = new Manager { Id = Guid.NewGuid(), UserId = testUserId };

			managerRepository
				.Setup(repo => repo.FirstorDefaultAsync(It.IsAny<Expression<Func<Manager, bool>>>()))
				.ReturnsAsync(manager);
			managerRepository
				.Setup(repo => repo.DeleteAsync(It.IsAny<Guid>()))
				.ReturnsAsync(false);

			IManagerService managerService = new ManagerService(managerRepository.Object);

			var result = await managerService.RemoveManagerAsync(testUserId);

			Assert.IsFalse(result);
			managerRepository.Verify(repo => repo.DeleteAsync(manager.Id), Times.Once); 
		}
	}
}

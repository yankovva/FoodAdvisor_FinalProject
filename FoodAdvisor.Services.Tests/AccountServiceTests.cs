using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.AccountViemModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants;

namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	public class AccountServiceTests
	{
		private Mock<IRepository<ApplicationUser, Guid>> accountRepository;
		private Mock<UserManager<ApplicationUser>> userManager;
		private Mock<IFileService> fileService;
	
		[SetUp]
		public void Setup()
		{
			this.accountRepository = new Mock<IRepository<ApplicationUser, Guid>>();
			this.fileService = new Mock<IFileService>();
			var store = new Mock<IUserStore<ApplicationUser>>();
			this.userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
		}
		[Test]
		public async Task GetEditUserViewAsync_ShouldReturnModel_WhenUserExists()
		{
			var userId = Guid.NewGuid();
			var testUser = new ApplicationUser
			{
				Id = userId,
				FirstName = "John",
				LastName = "Doe",
				AboutMe = "Lorem ipsum",
				Country = "USA",
				UserName = "johndoe",
				ProfilePricturePath = "path/to/image.jpg"
			};

			var users = new List<ApplicationUser> { testUser }.AsQueryable().BuildMock();
			accountRepository
			.Setup(repo => repo.GetAllAttached())
				.Returns(users);

			IAccountService accountService = new AccountService(accountRepository.Object, null,fileService.Object);
			var result = await accountService.GetEditUserViewAsync(userId);

			Assert.IsNotNull(result);
			Assert.That(result.FirstName, Is.EqualTo("John"));
			Assert.That(result.LastName, Is.EqualTo("Doe"));
			
		}
		[Test]
		public async Task GetEditUserViewAsync_ShouldReturnNull_WhenUserDoesNotExist()
		{
			var userId = Guid.NewGuid();

			var users = new List<ApplicationUser>().AsQueryable().BuildMock();

			accountRepository
				.Setup(repo => repo.GetAllAttached())
				.Returns(users);

			IAccountService accountService = new AccountService(accountRepository.Object, null, fileService.Object);
			var result = await accountService.GetEditUserViewAsync(userId);

			Assert.IsNull(result);
		}
		[Test]
		public async Task EditUserAsync_ShouldReturnFalse_WhenUserIdIsInvalid()
		{
			var model = new EditUserViewModel();
			var invalidUserId = "invalid-guid";

			IAccountService accountService = new AccountService(accountRepository.Object, null, fileService.Object);

			var result = await accountService.EditUserAsync(model, invalidUserId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task EditUserAsync_ShouldUpdateUser_WhenDataIsValid()
		{
			var userId = Guid.NewGuid().ToString();
			var userGuid = Guid.Parse(userId);
			var model = new EditUserViewModel
			{
				FirstName = "John",
				LastName = "Doe",
				AboutMe = "Lorem ipsum",
				Country = "USA",
				UserName = "newusername",
				Email = "newemail@example.com"
			};

			var existingUser = new ApplicationUser
			{
				Id = userGuid,
				UserName = "oldusername",
				Email = "oldemail@example.com",
				FirstName = "Old",
				LastName = "Name",
				AboutMe = "Old bio",
				Country = "Old country"
			};

			accountRepository
				.Setup(repo => repo.GetByIdAsync(userGuid))
				.ReturnsAsync(existingUser);

			userManager
				.Setup(um => um.SetUserNameAsync(existingUser, model.UserName))
				.ReturnsAsync(IdentityResult.Success);

			userManager
				.Setup(um => um.SetEmailAsync(existingUser, model.Email))
				.ReturnsAsync(IdentityResult.Success);

			IAccountService accountService = new AccountService(accountRepository.Object, userManager.Object, fileService.Object);

			var result = await accountService.EditUserAsync(model, userId);

			Assert.IsTrue(result);
			Assert.That(existingUser.FirstName, Is.EqualTo(model.FirstName));
			Assert.That(existingUser.LastName, Is.EqualTo(model.LastName));
			Assert.That(existingUser.AboutMe, Is.EqualTo(model.AboutMe));
			Assert.That(existingUser.Country, Is.EqualTo(model.Country));
			accountRepository.Verify(repo => repo.UpdateAsync(existingUser), Times.Once);
		}
		[Test]
		public async Task UpdateProfilePictureAsync_ShouldReturnFalse_WhenUserNotFound()
		{
			var userId = Guid.NewGuid();
			IFormFile file = null;

			accountRepository
			.Setup(repo => repo.GetByIdAsync(userId))
			.ReturnsAsync((ApplicationUser)null);

			IAccountService accountService = new AccountService(accountRepository.Object, userManager.Object, fileService.Object);

			var result = await accountService.UpdateProfilePictureAsync(file, userId);

			Assert.IsFalse(result);
		}
		[Test]
		public async Task UpdateProfilePictureAsync_ShouldThrowException_WhenFileIsInvalid()
		{
			var userId = Guid.NewGuid();
			var user = new ApplicationUser
			{
				Id = userId,
				UserName = "TestUser",
				ProfilePricturePath = null
			};

			var mockFile = new Mock<IFormFile>();
			mockFile
				.Setup(f => f.Length)
				.Returns(1);
			mockFile
				.Setup(f => f.FileName)
				.Returns("test.jpg");

			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			long maxSize = 5 * 1024 * 1024;

			accountRepository
				.Setup(repo => repo.GetByIdAsync(userId))
				.ReturnsAsync(user);

			fileService
				.Setup(fs => fs.IsFileValid(mockFile.Object, allowedExtensions, maxSize))
				.Returns(false);

			IAccountService accountService = new AccountService(accountRepository.Object, userManager.Object, fileService.Object);

			Assert.ThrowsAsync<ArgumentException>(async () => await accountService.UpdateProfilePictureAsync(mockFile.Object, userId));
		}
	}
}

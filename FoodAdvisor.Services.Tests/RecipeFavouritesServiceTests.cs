using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using MockQueryable;
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
	public class RecipeFavouritesServiceTests
	{
		
		private Mock<IRepository<Recepie, Guid>> recepieRepository;
		private Mock<IRepository<UserRecepie, object>> userRecepieRepository;

		[SetUp]
		public void Setup()
		{
			this.recepieRepository = new Mock<IRepository<Recepie, Guid>>();
			this.userRecepieRepository = new Mock<IRepository<UserRecepie, object>>();

		}

		[Test]
		public async Task AddToFavouritesAsyncValidRecepieNotAlreadyAddeAddsToFavouritesReturnsTrue()
		{
			var recepieId = Guid.NewGuid().ToString();
			var recepieGuid = Guid.Parse(recepieId);
			var userId = Guid.NewGuid();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				 .Returns(new List<Recepie>
			{
				new Recepie
				{
					Id = recepieGuid,
					IsDeleted = false
				}
			}.AsQueryable()
			.BuildMock());

			this.userRecepieRepository
				.Setup(ur => ur.GetAllAttached())
				.Returns(new List<UserRecepie>().AsQueryable().BuildMock());

			this.userRecepieRepository
				.Setup(ur => ur.AddAsync(It.IsAny<UserRecepie>()))
			.Returns(Task.CompletedTask);

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);

			var result = await favouriteService.AddToFavouritesAsync(userId, recepieId);

			Assert.IsTrue(result);
			this.userRecepieRepository.Verify(ur => ur.AddAsync(It.Is<UserRecepie>(
				u => u.ApplicationUserId == userId && u.RecepieId == recepieGuid)), Times.Once);
		}
		
		[Test]
		public async Task AddToFavouritesAsync_RecepieDoesNotExist_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var recepieId = Guid.NewGuid().ToString();
			var recepieGuid = Guid.Parse(recepieId);

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie>().AsQueryable().BuildMock());

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);

			var result = await favouriteService.AddToFavouritesAsync(userId, recepieId);

			Assert.IsFalse(result);
			this.userRecepieRepository.Verify(ur => ur.AddAsync(It.IsAny<UserRecepie>()), Times.Never);
		}
		[Test]
		public async Task AddToFavouritesAsync_InvalidRecepieId_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var invalidRecepieId = "invalid-guid";

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);

			var result = await favouriteService.AddToFavouritesAsync(userId, invalidRecepieId);

			Assert.IsFalse(result);
			this.userRecepieRepository.Verify(ur => ur.AddAsync(It.IsAny<UserRecepie>()), Times.Never);
		}
		[Test]
		public async Task RemoveFromFavouritesAsync_ValidFavourite_RemovesFromFavouritesAndReturnsTrue()
		{
			var userId = Guid.NewGuid();
			var recepieId = Guid.NewGuid().ToString();
			var recepieGuid = Guid.Parse(recepieId);

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie>
				{
				new Recepie { Id = recepieGuid, IsDeleted = false }
				}.AsQueryable().BuildMock());

			this.userRecepieRepository
				.Setup(ur => ur.FirstorDefaultAsync(It.IsAny<Expression<Func<UserRecepie, bool>>>()))
				.ReturnsAsync(new UserRecepie { ApplicationUserId = userId, RecepieId = recepieGuid });

			this.userRecepieRepository
				.Setup(ur => ur.DeleteAsync(It.IsAny<UserRecepie>()))
				.Returns(Task.CompletedTask);

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);

			var result = await favouriteService.RemoveFromFavouritesAsync(userId, recepieId);

			Assert.IsTrue(result);
			this.userRecepieRepository.Verify(ur => ur.DeleteAsync(It.Is<UserRecepie>(
				u => u.ApplicationUserId == userId && u.RecepieId == recepieGuid)), Times.Once);
		}
		[Test]
		public async Task RemoveFromFavouritesAsync_RecepieDoesNotExist_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var recepieId = Guid.NewGuid().ToString();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie>().AsQueryable().BuildMock());

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);

			var result = await favouriteService.RemoveFromFavouritesAsync(userId, recepieId);

			Assert.IsFalse(result);
			this.userRecepieRepository.Verify(ur => ur.DeleteAsync(It.IsAny<UserRecepie>()), Times.Never);
		}
		[Test]
		public async Task RemoveFromFavouritesAsync_InvalidRecepieId_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var invalidRecepieId = "invalid-guid";

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);

			var result = await favouriteService.RemoveFromFavouritesAsync(userId, invalidRecepieId);

			Assert.IsFalse(result);
			this.userRecepieRepository.Verify(ur => ur.DeleteAsync(It.IsAny<UserRecepie>()), Times.Never);
		}

		
	}
}

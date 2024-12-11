using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.Data.Services;
using MockQueryable;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockQueryable.Moq;
using System.Linq.Expressions;

namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	public class RestaurantFavouriteServiceTests
	{
		private Mock<IRepository<Restaurant, Guid>> restaurantRepository;
		private Mock<IRepository<UserRestaurant, object>> userRestaurantRepository;

		[SetUp]
		public void Setup()
		{
			this.restaurantRepository = new Mock<IRepository<Restaurant, Guid>>();
			this.userRestaurantRepository = new Mock<IRepository<UserRestaurant, object>>();

		}

		[Test]
		public async Task AddToFavouritesAsync_ValidRestaurant_AddsToFavouritesAndReturnsTrue()
		{
			var userId = Guid.NewGuid();
			var restaurantId = Guid.NewGuid().ToString();
			var restaurantGuid = Guid.Parse(restaurantId);
			var restaurant = new Restaurant
			{
				Id = restaurantGuid,
				Name = "Test Restaurant",
				IsDeleted = false
			};

			restaurantRepository
				.Setup(rr => rr.GetAllAttached())
				.Returns(new List<Restaurant> { restaurant }.AsQueryable().BuildMock());

			userRestaurantRepository
				.Setup(urr => urr.GetAllAttached())
				.Returns(new List<UserRestaurant>().AsQueryable().BuildMock());

			userRestaurantRepository
				.Setup(urr => urr.AddAsync(It.IsAny<UserRestaurant>()))
				.Returns(Task.CompletedTask);

			IRestaurantFavouritesService favouriteService = new RestaurantFavouritesService(restaurantRepository.Object, userRestaurantRepository.Object);

			var result = await favouriteService.AddToFavouritesAsync(userId, restaurantId);

			Assert.IsTrue(result);
			userRestaurantRepository.Verify(urr => urr.AddAsync(It.Is<UserRestaurant>(ur =>
				ur.ApplicationUserId == userId && ur.RestaurantId == restaurantGuid)), Times.Once);
		}
		
		[Test]
		public async Task AddToFavouritesAsync_RestauranteDoesNotExist_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var restaurantId = Guid.NewGuid().ToString();
			var restaurantGuid = Guid.Parse(restaurantId);

			this.restaurantRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Restaurant>().AsQueryable().BuildMock());

			IRestaurantFavouritesService favouriteService = new RestaurantFavouritesService(restaurantRepository.Object, userRestaurantRepository.Object);

			var result = await favouriteService.AddToFavouritesAsync(userId, restaurantId);

			Assert.IsFalse(result);
			this.userRestaurantRepository.Verify(ur => ur.AddAsync(It.IsAny<UserRestaurant>()), Times.Never);
		}

		[Test]
		public async Task AddToFavouritesAsync_InvalidRecepieId_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var invalidRestaurantId = "invalid-guid";

			IRestaurantFavouritesService favouriteService = new RestaurantFavouritesService(restaurantRepository.Object, userRestaurantRepository.Object);

			var result = await favouriteService.AddToFavouritesAsync(userId, invalidRestaurantId);

			Assert.IsFalse(result);
			this.userRestaurantRepository.Verify(ur => ur.AddAsync(It.IsAny<UserRestaurant>()), Times.Never);
		}
		[Test]
		public async Task RemoveFromFavouritesAsync_ValidRestaurant_RemovesFromFavouritesAndReturnsTrue()
		{
			var userId = Guid.NewGuid();
			var restaurantId = Guid.NewGuid().ToString();
			var restaurantGuid = Guid.Parse(restaurantId);
			var restaurant = new Restaurant
			{
				Id = restaurantGuid,
				IsDeleted = false
			};
			var userRestaurant = new UserRestaurant
			{
				ApplicationUserId = userId,
				RestaurantId = restaurantGuid
			};

			restaurantRepository
				.Setup(rr => rr.GetAllAttached())
				.Returns(new List<Restaurant> { restaurant }.AsQueryable().BuildMock());

			userRestaurantRepository
				.Setup(urr => urr.FirstorDefaultAsync(It.IsAny<Expression<Func<UserRestaurant, bool>>>()))
				.ReturnsAsync(userRestaurant);

			userRestaurantRepository
				.Setup(urr => urr.DeleteAsync(It.IsAny<UserRestaurant>()))
				.Returns(Task.CompletedTask);

			IRestaurantFavouritesService favouriteService = new RestaurantFavouritesService(restaurantRepository.Object, userRestaurantRepository.Object);

			var result = await favouriteService.RemoveFromFavouritesAsync(userId, restaurantId);

			Assert.IsTrue(result);
			userRestaurantRepository.Verify(urr => urr.DeleteAsync(It.Is<UserRestaurant>(ur =>
				ur.ApplicationUserId == userId && ur.RestaurantId == restaurantGuid)), Times.Once);
		}

		[Test]
		public async Task RemoveFromFavouritesAsync_RestaurantNotFound_ReturnsFalse()
		{
			var userId = Guid.NewGuid();
			var restaurantId = Guid.NewGuid().ToString();
			var restaurantGuid = Guid.Parse(restaurantId);

			restaurantRepository
				.Setup(rr => rr.GetAllAttached())
				.Returns(new List<Restaurant>().AsQueryable().BuildMock());

			IRestaurantFavouritesService favouriteService = new RestaurantFavouritesService(restaurantRepository.Object, userRestaurantRepository.Object);

			var result = await favouriteService.RemoveFromFavouritesAsync(userId, restaurantId);

			Assert.IsFalse(result);
			userRestaurantRepository.Verify(urr => urr.DeleteAsync(It.IsAny<UserRestaurant>()), Times.Never);
		}
	}
}

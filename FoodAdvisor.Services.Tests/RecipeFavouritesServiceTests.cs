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
		private IList<Recepie> recipeData = new List<Recepie>()
		{
			new Recepie()
			{
				Id = Guid.Parse("7E5B4C9D-3F6A-8B2A-9C7E-2D6F3B5A9E4C"),
				Name = "Baked Ziti",
				CookingTime = 40,
				CreatedOn = new DateTime(2023, 11,23),
				Description = "A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère cheese.",
				ImageURL = "RecepiePictures\\Creamy Garlic Pasta_10.jpg",
				PublisherId = Guid.Parse("B2C8567C-A0B5-49AC-9C11-12C760DC4CC4"),
				RecepieCategory = new RecepieCategory { Name = "Bulgarian" },
				RecepieCategoryId=Guid.Parse("2A5CC5EF-0991-4763-8A6F-7B6EAD6BCA23"),
				Publisher = new ApplicationUser { UserName = "John Doe", ProfilePricturePath = "path/to/picture" },
				RecepieDificulty = new RecepieDificulty { DificultyName = "Medium" },
				NumberOfServing = 4,
				IsDeleted = false,
				RecepieDificultyId = 3,
				Products = "Dark Chocolate, Butter, Eggs, Sugar, Flour, Powdered Sugar",
				CookingSteps = "Cook the pasta according to package instructions until al dente.In a large pan, heat olive oil over medium-high heat and sauté garlic until fragrant.Add shrimp to the pan and cook for 2-3 minutes on each side, until they turn pink and opaque.Add lemon juice, zest, and a pinch of red pepper flakes. Stir to combine.Toss the cooked pasta into the pan with the shrimp, adding a bit of pasta water to create a light sauce.Garnish with fresh parsley and serve immediately.Serve hot, garnished with fresh basil and grated Parmesan cheese, if desired."
			},
			new Recepie()
			{
				Id = Guid.Parse("E3B7D9C2-A4F8-5B6A-3D9E-7C2F5A9E6B4D"),
				Name = "Cake",
				CookingTime = 90,
				CreatedOn = new DateTime(2022, 10,4),
				Description = "A vibrant and aromatic Thai curry with a spicy coconut milk base, tender chicken, and fresh vegetables. Serve with jasmine rice.",
				ImageURL = "RecepiePictures\\Vegan Buddha Bowl_7.jpg",
				PublisherId = Guid.Parse("7DF25137-B39A-4A91-903B-303C0582E389"),
				Publisher = new ApplicationUser { UserName = "John Doe", ProfilePricturePath = "path/to/picture" },
				RecepieCategory = new RecepieCategory { Name = "Italian" },
				RecepieCategoryId=Guid.Parse("2A5CC5EF-0991-4763-8A6F-7B6EAD6BCA23"),
				Products = "Dark Chocolate, Butter, Eggs, Sugar, Flour, Powdered Sugar",
				CookingSteps = "Heat olive oil in a large skillet over medium-high heat. Brown the beef strips, then set them aside.In the same skillet, melt butter and sauté onions for 4-5 minutes until softened. Add garlic and cook for another minute.Add mushrooms and cook until browned, about 5-7 minutes.Sprinkle flour over the mixture and stir to combine.Gradually pour in the beef broth, stirring constantly. Add sour cream and simmer for 5 minutes until the sauce thickens.Return beef to the skillet, season with salt and pepper, and serve over egg noodles.Add the tomatoes, beans, and pasta to the pot. Stir and continue to simmer for another 10-15 minutes, or until the pasta is cooked.Season with salt, pepper, and Italian herbs to taste.",
				NumberOfServing = 6,
				RecepieDificultyId = 3,
				RecepieDificulty = new RecepieDificulty { DificultyName = "Medium" },
				IsDeleted = false,

			}
		};
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
		public async Task AddToFavouritesAsync_RecepieAlreadyFavourite_ReturnsFalse()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var recepieId = Guid.NewGuid().ToString();
			var recepieGuid = Guid.Parse(recepieId);

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
				.Returns(new List<UserRecepie>
				{
				new UserRecepie
				{
					ApplicationUserId = userId,
					RecepieId = recepieGuid
				}
				}.AsQueryable()
				.BuildMock());

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);
			
			var result = await favouriteService.AddToFavouritesAsync(userId, recepieId);

			Assert.IsFalse(result);
			this.userRecepieRepository.Verify(ur => ur.AddAsync(It.IsAny<UserRecepie>()), Times.Never);
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

		[Test]
		public async Task InedexGetAllFavouritesAsync_ValidUserId_ReturnsFavourites()
		{
			var userId = Guid.NewGuid().ToString();
			var recepies = new List<UserRecepie>
		{
			new UserRecepie
			{
				ApplicationUserId = Guid.Parse(userId),
				Recepie = new Recepie
				{
					Id = Guid.Parse("7E5B4C9D-3F6A-8B2A-9C7E-2D6F3B5A9E4C"),
					Name = "Baked Ziti",
					CookingTime = 40,
					CreatedOn = new DateTime(2023, 11,23),
					Description = "A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère cheese.",
					ImageURL = "RecepiePictures\\Creamy Garlic Pasta_10.jpg",
					PublisherId = Guid.Parse("B2C8567C-A0B5-49AC-9C11-12C760DC4CC4"),
					RecepieCategory = new RecepieCategory { Name = "Bulgarian" },
					RecepieCategoryId=Guid.Parse("2A5CC5EF-0991-4763-8A6F-7B6EAD6BCA23"),
					Publisher = new ApplicationUser { UserName = "John Doe", ProfilePricturePath = "path/to/picture" },
					RecepieDificulty = new RecepieDificulty { DificultyName = "Medium" },
					NumberOfServing = 4,
					IsDeleted = false,
					RecepieDificultyId = 3,
					Products = "Dark Chocolate, Butter, Eggs, Sugar, Flour, Powdered Sugar",
					CookingSteps = "Heat olive oil in a large skillet over medium-high heat. Brown the beef strips, then set them aside.In the same skillet,"
				}
			}
		};

			this.userRecepieRepository
				.Setup(ur => ur.GetAllAttached())
				.Returns(recepies.AsQueryable().BuildMock());

			IRecepieFavouritesService favouriteService = new RecepieFavouritesService(recepieRepository.Object, userRecepieRepository.Object);


			var result = await favouriteService.InedexGetAllFavouritesAsync(userId);

			Assert.IsNotNull(result);
			Assert.That(result.Count(), Is.EqualTo(1));
			var recepie = result.First();
			Assert.That(recepie.Name, Is.EqualTo("Baked Ziti"));
		}
	}
}

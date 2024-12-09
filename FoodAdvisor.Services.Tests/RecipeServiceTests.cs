using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MockQueryable;
using Moq;
using System;
using static FoodAdvisor.Common.ErrorMessages;


namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	public class RecipeServiceTests
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
		private Mock<IFileService> fileService;

		[SetUp]
		public void Setup()
		{
			this.recepieRepository = new Mock<IRepository<Recepie, Guid>>();
			this.userRecepieRepository = new Mock<IRepository<UserRecepie, object>>();
			this.fileService = new Mock<IFileService>();
		}

		[Test]
		public async Task GetAllRecipesNoFilterPositive()
		{
			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			IEnumerable<RecepieIndexViewModel> allRecipes = await recipeService
			   .IndexGetAllRecepiesAsync(new FilterIndexRecipeViewModel());

			Assert.IsNotNull(allRecipes);
			Assert.That(this.recipeData.Count(), Is.EqualTo(allRecipes.Count()));

			allRecipes = allRecipes
				.OrderBy(r => r.Id)
				.ToList();

			int i = 0;
			foreach (var recipe in allRecipes)
			{
				Assert.That(this.recipeData.OrderBy(r => r.Id).ToList()[i++].Id.ToString(), Is.EqualTo(recipe.Id));
			}
		}

		[Test]
		[TestCase("Cake")]
		[TestCase("cake")]
		public async Task GetAllRecipesQuerySearchPositive(string searchQuery)
		{
			int expectedCount = 1;
			string expectedRecipeId = "E3B7D9C2-A4F8-5B6A-3D9E-7C2F5A9E6B4D";

			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			IEnumerable<RecepieIndexViewModel> allRecipes = await recipeService
			   .IndexGetAllRecepiesAsync(new FilterIndexRecipeViewModel()
			   {
				   SearchQuery = searchQuery
			   });

			Assert.IsNotNull(allRecipes);
			Assert.That(expectedCount, Is.EqualTo(allRecipes.Count()));
			Assert.That(expectedRecipeId.ToLower(), Is.EqualTo(allRecipes.First().Id.ToLower()));

		}
		[Test]
		public async Task GetAllRecipesFilterCategoryPositive()
		{
			int expectedCount = 1;
			string expectedRecipeId = "E3B7D9C2-A4F8-5B6A-3D9E-7C2F5A9E6B4D";

			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			IEnumerable<RecepieIndexViewModel> allRecipes = await recipeService
			   .IndexGetAllRecepiesAsync(new FilterIndexRecipeViewModel()
			   {
				   CategoryFilter = "Italian"
			   });

			Assert.IsNotNull(allRecipes);
			Assert.That(expectedCount, Is.EqualTo(allRecipes.Count()));
			Assert.That(expectedRecipeId.ToLower(), Is.EqualTo(allRecipes.First().Id.ToLower()));

		}
		[Test]
		public async Task GetAllRecipesFilterDificultyPositive()
		{
			int expectedCount = 2;

			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			IEnumerable<RecepieIndexViewModel> allRecipes = await recipeService
			   .IndexGetAllRecepiesAsync(new FilterIndexRecipeViewModel()
			   {
				   DificultyFilter = "Medium"
			   });

			Assert.IsNotNull(allRecipes);
			Assert.That(expectedCount, Is.EqualTo(allRecipes.Count()));

			allRecipes = allRecipes
				.OrderBy(r => r.Id)
				.ToList();
			int i = 0;
			foreach (var recepie in allRecipes)
			{
				Assert.That(this.recipeData.OrderBy(r => r.Id).ToList()[i++].Id.ToString(), Is.EqualTo(recepie.Id));
			}

		}
		[Test]
		[TestCase("potato")]
		[TestCase("Ziti")]
		public async Task GetAllRecipesAllFiltersNegative(string searchWord)
		{
			int expectedCount = 0;

			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			IEnumerable<RecepieIndexViewModel> allRecipes = await recipeService
			   .IndexGetAllRecepiesAsync(new FilterIndexRecipeViewModel()
			   {
				   DificultyFilter = "Medium",
				   CategoryFilter = "Italian",
				   SearchQuery = "searchWord"
			   });

			Assert.IsNotNull(allRecipes);
			Assert.That(expectedCount, Is.EqualTo(allRecipes.Count()));

		}
		[Test]
		[TestCase("Ca")]
		[TestCase("cake")]
		public async Task GetAllRecipesAllFiltersPositive(string searchWord)
		{
			int expectedCount = 1;
			string expectedRecipeId = "E3B7D9C2-A4F8-5B6A-3D9E-7C2F5A9E6B4D";

			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			IEnumerable<RecepieIndexViewModel> allRecipes = await recipeService
			   .IndexGetAllRecepiesAsync(new FilterIndexRecipeViewModel()
			   {
				   DificultyFilter = "Medium",
				   CategoryFilter = "Italian",
				   SearchQuery = searchWord
			   });

			Assert.IsNotNull(allRecipes);
			Assert.That(expectedCount, Is.EqualTo(allRecipes.Count()));
			Assert.That(expectedRecipeId.ToLower(), Is.EqualTo(allRecipes.First().Id.ToLower()));

		}
		[Test]
		public async Task GetAlRecipesNullFilterNegative()
		{

			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			Assert.ThrowsAsync<NullReferenceException>(async () =>
			{
				IEnumerable<RecepieIndexViewModel> allMoviesActual = await recipeService
					.IndexGetAllRecepiesAsync(null);
			});
		}
		[Test]
		public async Task AddRecepiesAsyncSHouldThrowExeptionWhenFileIsInvalid()
		{

			this.fileService
				.Setup(fs => fs.IsFileValid(It.IsAny<IFormFile>(), It.IsAny<string[]>(), It.IsAny<long>()))
				.Returns(false);

			var model = new AddRecepieViewModel
			{
				Name = "Pasta",
				Description = "A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère cheese.",
				CookingTime = 30,
				CategoryId = Guid.NewGuid(),
				Products = "Pasta, Tomato Sauce-900,Tomato, beef ",
				Servings = 4,
				DificultyId = 2,
				CookingSteps = "A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère cheese."
			};

			var userId = Guid.NewGuid();
			var mockFile = new Mock<IFormFile>();

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var exeption = Assert.ThrowsAsync<ArgumentException>(async () =>
				await recipeService.AddRecepiesAsync(model, userId, mockFile.Object));

			Assert.That(exeption.Message, Is.EqualTo(InvalidFileMessage));
		}


		[Test]
		public async Task AddRecepiesAsyncShouldAddRecipeWhenEverythingIsValidPositive()
		{
			var model = new AddRecepieViewModel
			{
				Name = "Pasta",
				Description = "A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère cheese.",
				CookingTime = 30,
				CategoryId = Guid.NewGuid(),
				Products = "Pasta, Tomato Sauce-900,Tomato, beef ",
				Servings = 4,
				DificultyId = 2,
				CookingSteps = "A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère cheese."
			};

			var userId = Guid.NewGuid();
			var mockFile = new Mock<IFormFile>();

			var filePath = "path/to/file.jpg";

			fileService
				.Setup(fs => fs.IsFileValid(It.IsAny<IFormFile>(), It.IsAny<string[]>(), It.IsAny<long>()))
				.Returns(true);
			fileService
				.Setup(fs => fs.UploadFileAsync(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync(filePath);

			var recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			await recipeService.AddRecepiesAsync(model, userId, mockFile.Object);


			fileService
				.Verify(fs => fs.UploadFileAsync(mockFile.Object, It.IsAny<string>(), It.IsAny<string>()), Times.Once);

			recepieRepository
				.Verify(r => r.AddAsync(It.Is<Recepie>(r => r.Name == model.Name && r.Description == model.Description)), Times.Once);
		}
		[Test]
		public async Task GetRecepietDetailsAsync_ValidGuid_ShouldReturnCorrectDetailsPositive()
		{
			var validId = Guid.NewGuid();

			var recepieData = new Recepie
			{
				Id = validId,
				Name = "Test Recipe",
				Description = "Test Description",
				CookingSteps = "Test Steps",
				CreatedOn = new DateTime(2023, 12, 1),
				CookingTime = 30,
				Publisher = new ApplicationUser
				{
					UserName = "TestUser",
					FirstName = "John",
					LastName = "Doe",
					ProfilePricturePath = "path/to/picture.jpg",
					Country = "USA",
					AboutMe = "Cooking is fun! I Love it very much"
				},
				RecepieCategory = new RecepieCategory { Name = "Dessert" },
				RecepieDificulty = new RecepieDificulty { DificultyName = "Medium" },
				Products = "Sugar, Flour, Butter",
				NumberOfServing = 4,
				ImageURL = "path/to/image.jpg",
				RecepieComments = new List<Comment>
					{
						new Comment
							{
								Id = Guid.NewGuid(),
								Message = "Great recipe!",
								CreatedDate = new DateTime(2023, 12, 5),
								UserId = Guid.NewGuid(),
								User = new ApplicationUser
								{
									UserName = "CommentUser",
									ProfilePricturePath = "path/to/commenter.jpg"
								}
							}
						}
			};

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie> { recepieData }.AsQueryable().BuildMock());

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var result = await recipeService.GetRecepietDetailsAsync(validId.ToString());

			Assert.IsNotNull(result);
			Assert.That(result.Id, Is.EqualTo(validId));
			Assert.That(result.Name, Is.EqualTo("Test Recipe"));
			Assert.That(result.AllComment.Count(), Is.EqualTo(1));
			Assert.That(result.AllComment.First().Message, Is.EqualTo("Great recipe!"));
		}

		[Test]
		public void GetRecepietDetailsAsync_InvalidGuid_ShouldThrowArgumentExceptionNegative()
		{
			var invalidId = "invalid-guid";
			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
				await recipeService.GetRecepietDetailsAsync(invalidId));

			Assert.That(ex.Message, Is.EqualTo(InvalidGuidMessage));
		}
		[Test]
		public async Task GetRecepietDetailsAsync_ValidGuidButNotFound_ShouldReturnNullNegative()
		{

			var validId = Guid.NewGuid();
			recepieRepository.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie>().AsQueryable().BuildMock());

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var result = await recipeService.GetRecepietDetailsAsync(validId.ToString());

			Assert.IsNull(result);
		}

		[Test]
		public async Task DeleteRecepieViewAsync_ValidGuid_ReturnsModel()
		{
			var recepirdata = new Recepie
			{
				Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				Name = "Test Recipe",
				IsDeleted = false,
				CreatedOn = new DateTime(2023, 12, 5),
				ImageURL = "test_image.jpg",
				Publisher = new ApplicationUser
				{
					UserName = "TestUser"
				}
			};
			string validRecepieId = "11111111-1111-1111-1111-111111111111";
			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie> { recepirdata }.AsQueryable().BuildMock());

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var result = await recipeService.DeleteRecepieViewAsync(validRecepieId);

			Assert.IsNotNull(result);
			Assert.That(result.Id, Is.EqualTo(validRecepieId));
			Assert.That(result.Name, Is.EqualTo("Test Recipe"));
			Assert.That(result.Publisher, Is.EqualTo("TestUser"));
		}
		[Test]
		public void DeleteRecepieViewAsync_InvalidGuid_ThrowsArgumentException()
		{
			string invalidRecepieId = "invalid-guid";

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var ex = Assert.ThrowsAsync<ArgumentException>(() => recipeService.DeleteRecepieViewAsync(invalidRecepieId));
			Assert.That(ex.Message, Is.EqualTo(InvalidGuidMessage));
		}
		[Test]
		public async Task DeleteRecepieViewAsync_RecepieNotFound_ReturnsNull()
		{
			var recepirdata = new Recepie
			{
				Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				Name = "Test Recipe",
				IsDeleted = false,
				CreatedOn = new DateTime(2023, 12, 5),
				ImageURL = "test_image.jpg",
				Publisher = new ApplicationUser
				{
					UserName = "TestUser"
				}
			};
			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie> { recepirdata }.AsQueryable().BuildMock());

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			string nonExistingRecepieId = Guid.NewGuid().ToString();
			var result = await recipeService.DeleteRecepieViewAsync(nonExistingRecepieId);

			Assert.IsNull(result);
		}
		[Test]
		public async Task DeleteRecepieViewAsync_DeletedRecepie_ReturnsNull()
		{
			var recepirdata = new Recepie
			{
				Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				Name = "Test Recipe",
				IsDeleted = true,
				CreatedOn = new DateTime(2023, 12, 5),
				ImageURL = "test_image.jpg",
				Publisher = new ApplicationUser
				{
					UserName = "TestUser"
				}
			};
			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(new List<Recepie> { recepirdata }.AsQueryable().BuildMock());

			string deletedRecepieId = "11111111-1111-1111-1111-111111111111";

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var result = await recipeService.DeleteRecepieViewAsync(deletedRecepieId);

			Assert.IsNull(result);
		}
		[Test]
		public async Task DeleteRecepieAsync_ValidRecepieId_DeletesRecepieAndReturnsTrue()
		{
			var recepieData = new Recepie
			{
				Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				IsDeleted = false,
				ImageURL = "test_image.jpg"
			};

			recepieRepository.Setup(r => r.GetByIdAsync(recepieData.Id))
			.ReturnsAsync(recepieData);

			recepieRepository.Setup(r => r.SaveChangesAsync())
				.Returns(Task.CompletedTask);

			this.fileService.Setup(f => f.DeleteFile(recepieData.ImageURL));

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var model = new DeleteRecepieViewModel { Id = recepieData.Id.ToString() };
		
			var result = await recipeService.DeleteRecepieAsync(model);

			Assert.IsTrue(result);
			Assert.IsTrue(recepieData.IsDeleted);
			fileService.Verify(f => f.DeleteFile("test_image.jpg"), Times.Once);
			recepieRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
		}
		[Test]
		public async Task DeleteRecepieAsync_InvalidRecepieId_ReturnsFalse()
		{
			Guid nonExistingRecepieId = Guid.Parse("22222222-2222-2222-2222-222222222222");

			var recepieData = new Recepie
			{
				Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				IsDeleted = false,
				ImageURL = "test_image.jpg"
			};

			recepieRepository.Setup(r => r.GetByIdAsync(recepieData.Id))
			.ReturnsAsync(recepieData);

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var model = new DeleteRecepieViewModel { Id = nonExistingRecepieId.ToString() };

			var result = await recipeService.DeleteRecepieAsync(model);

			Assert.IsFalse(result);
			fileService.Verify(f => f.DeleteFile(It.IsAny<string>()), Times.Never);
			recepieRepository.Verify(r => r.SaveChangesAsync(), Times.Never);
		}
		[Test]
		public async Task DeleteRecepieAsync_RecepieAlreadyDeleted_ReturnsTrue()
		{
			var recepie = new Recepie
			{
				Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
				IsDeleted = true,
				ImageURL = "already_deleted.jpg"
			};

			recepieRepository.Setup(r => r.GetByIdAsync(recepie.Id))
				.ReturnsAsync(recepie);
			recepieRepository.Setup(r => r.SaveChangesAsync())
				.Returns(Task.CompletedTask);
			fileService.Setup(f => f.DeleteFile(recepie.ImageURL));

			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var model = new DeleteRecepieViewModel { Id = recepie.Id.ToString() };

			var result = await recipeService.DeleteRecepieAsync(model);

			Assert.IsTrue(result);
			fileService.Verify(f => f.DeleteFile("already_deleted.jpg"), Times.Once);
			recepieRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
		}
		[Test]
		public async Task EditRecepieAsync_ValidRecepieId_UpdatesRecepieAndReturnsTrue()
		{
			var recepieId = Guid.NewGuid().ToString();
			var userId = Guid.NewGuid();

			var fileMock = new Mock<IFormFile>();

			var model = new AddRecepieViewModel
			{
				Name = "Updated Name",
				Description = "Updated Description A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère",
				CookingTime = 60,
				Products = "Product1, Product2",
				CategoryId = Guid.NewGuid(),
				DificultyId = 1,
				Servings = 4,
				CookingSteps = "Step1, Step2 A classic French dish made with caramelized onions, rich beef broth, and topped with a slice of crusty bread and melted Gruyère"
			};

			var recepie = new Recepie
			{
				Id = Guid.Parse(recepieId),
				ImageURL = "old_image.jpg",
				IsDeleted = false
			};

			recepieRepository
				.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
				.ReturnsAsync(recepie);
			fileService
				.Setup(f => f.IsFileValid(fileMock.Object, It.IsAny<string[]>(), It.IsAny<long>()))
				.Returns(true);
			fileService
				.Setup(f => f.UploadFileAsync(fileMock.Object, It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync("new_image.jpg");
			fileService
				.Setup(f => f.DeleteFile(It.IsAny<string>()));
			
			IRecepieService recipeService = new RecepieService(recepieRepository.Object, userRecepieRepository.Object, fileService.Object);

			var result = await recipeService.EditRecepieAsync(model, recepieId, userId, fileMock.Object);

			Assert.IsTrue(result);
			Assert.That(recepie.ImageURL, Is.EqualTo("new_image.jpg"));
			fileService.Verify(f => f.DeleteFile("old_image.jpg"), Times.Once);
			recepieRepository.Verify(r => r.UpdateAsync(recepie), Times.Once);
		}
	}
}



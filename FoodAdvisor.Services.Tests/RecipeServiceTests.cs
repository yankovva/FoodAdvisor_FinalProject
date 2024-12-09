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
		public async Task AddRecipeSHouldThrowExeptionWhenFileIsInvalid()
		{
			IQueryable<Recepie> recipesMockQueryable = recipeData.BuildMock();

			this.recepieRepository
				.Setup(r => r.GetAllAttached())
				.Returns(recipesMockQueryable);

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
		public async Task AddRecepiesAsyncShouldThrowArgumentExceptionWhenGuidIsInvalid()
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

			var invalidUserId = "invalid-user-id";
			var fileMock = new Mock<IFormFile>();

			this.fileService
				.Setup(f => f.IsFileValid(It.IsAny<IFormFile>(), It.IsAny<string[]>(), It.IsAny<long>()))
				.Returns(true);
			this.fileService
				.Setup(f => f.UploadFileAsync(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync("test-path");

			var recipeService = new RecepieService(this.recepieRepository.Object, this.userRecepieRepository.Object, this.fileService.Object);

			var ex = Assert.ThrowsAsync<FormatException>(async () =>
			{
				await recipeService.AddRecepiesAsync(model, Guid.Parse(invalidUserId), fileMock.Object);
			});
			Assert.That(ex.Message, Is.EqualTo(InvalidErrorMessage));
		}

		[Test]
		public async Task AddRecepieShouldAddRecipeWhenEverythingIsValidPositive()
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
	}

}

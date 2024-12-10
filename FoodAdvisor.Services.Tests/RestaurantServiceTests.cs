using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.Data.Services;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MockQueryable;

namespace FoodAdvisor.Services.Tests
{
    [TestFixture]
    public class RestaurantServiceTests
    {
        private Mock<IRepository<Restaurant, Guid>> restaurantRepositoryMock;
        private Mock<IRepository<City, Guid>> cityRepositoryMock;
        private Mock<IRepository<Manager, Guid>> managerRepositoryMock;
        private Mock<IRepository<RestaurantCuisine, Guid>> cuisineRepositoryMock;
        private Mock<IWebHostEnvironment> environmentMock;
        private Mock<IFileService> fileServiceMock;
        private RestaurantService restaurantService;

        [SetUp]
        public void SetUp()
        {
            restaurantRepositoryMock = new Mock<IRepository<Restaurant, Guid>>();
            cityRepositoryMock = new Mock<IRepository<City, Guid>>();
            managerRepositoryMock = new Mock<IRepository<Manager, Guid>>();
            cuisineRepositoryMock = new Mock<IRepository<RestaurantCuisine, Guid>>();
            environmentMock = new Mock<IWebHostEnvironment>();
            fileServiceMock = new Mock<IFileService>();

            restaurantService = new RestaurantService(
                restaurantRepositoryMock.Object,
                cityRepositoryMock.Object,
                environmentMock.Object,
                cuisineRepositoryMock.Object,
                fileServiceMock.Object,
                managerRepositoryMock.Object);
        }

        [Test]
        public async Task AddRestaurantAsync_ValidInputs_AddsRestaurant()
        {
            var model = new RestaurantAddViewModel
            {
                Name = "Test Restaurant",
                City = "Test City",
                CuisineName = "Test Cuisine",
                CategoryId = Guid.NewGuid(),
                Address = "Test Address",
                PriceRange = 50
            };
            var userId = Guid.NewGuid();
            var fileMock = new Mock<IFormFile>();
            var fileDishMock = new Mock<IFormFile>();

            fileServiceMock.Setup(f => f.IsFileValid(It.IsAny<IFormFile>(), It.IsAny<string[]>(), It.IsAny<long>())).Returns(true);
            fileServiceMock.Setup(f => f.UploadFileAsync(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync("path");

            managerRepositoryMock
                .Setup(m => m.FirstorDefaultAsync(It.IsAny<Expression<Func<Manager, bool>>>()))
                .ReturnsAsync(new Manager { Id = Guid.NewGuid() });

            await restaurantService.AddRestaurantAsync(model, userId, fileMock.Object, fileDishMock.Object);

            restaurantRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Restaurant>()), Times.Once);
        }

        [Test]
        public async Task DeleteRestaurantAsync_ValidId_ReturnsTrue()
        {
            var restaurantId = Guid.NewGuid();
            var model = new RestaurantDeleteViewModel { Id = restaurantId.ToString() };

            restaurantRepositoryMock
                .Setup(r => r.GetByIdAsync(restaurantId))
                .ReturnsAsync(new Restaurant { Id = restaurantId });

            var result = await restaurantService.DeleteRestaurantAsync(model);

            Assert.IsTrue(result);
            restaurantRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteRestaurantAsync_InvalidId_ReturnsFalse()
        {
            var restaurantId = Guid.NewGuid();
            var model = new RestaurantDeleteViewModel { Id = restaurantId.ToString() };

            restaurantRepositoryMock
                .Setup(r => r.GetByIdAsync(restaurantId))
                .ReturnsAsync((Restaurant)null);

            var result = await restaurantService.DeleteRestaurantAsync(model);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task EditRestaurantAsync_ValidInputs_UpdatesRestaurant()
        {
            var restaurantId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var model = new RestaurantAddViewModel
            {
                Name = "Updated Restaurant",
                City = "Updated City",
                CuisineName = "Updated Cuisine",
                Address = "Updated Address"
            };
            var fileMock = new Mock<IFormFile>();
            var fileDishMock = new Mock<IFormFile>();

            restaurantRepositoryMock
                .Setup(r => r.GetByIdAsync(restaurantId))
                .ReturnsAsync(new Restaurant { Id = restaurantId });
            fileServiceMock
                .Setup(f => f.IsFileValid(It.IsAny<IFormFile>(), It.IsAny<string[]>(), It.IsAny<long>()))
                .Returns(true);
            fileServiceMock
                .Setup(f => f.UploadFileAsync(It.IsAny<IFormFile>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync("path");
            managerRepositoryMock
                .Setup(m => m.FirstorDefaultAsync(It.IsAny<Expression<Func<Manager, bool>>>()))
                .ReturnsAsync(new Manager { Id = Guid.NewGuid() });

            var result = await restaurantService
                .EditRestaurantAsync(model, restaurantId, userId, fileMock.Object, fileDishMock.Object);

            Assert.IsTrue(result);
            restaurantRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Restaurant>()), Times.Once);
        }

       
       
        [Test]
        public async Task GetRestaurantDetailsAsync_ValidId_ReturnsCorrectDetails()
        {
            var restaurantId = Guid.NewGuid();

            restaurantRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(new List<Restaurant>
                {
                new Restaurant
                {
                    Id = restaurantId,
                    Name = "Test Restaurant",
                    Description = "Test Description",
                    ImageURL = "path/to/image",
                    ChefsSpecial = "Special Dish",
                    ChefsSpecialImage = "path/to/dish",
                    City = new City { Name = "City Name" },
                    Cuisine = new RestaurantCuisine { Name = "Cuisine Name" },
                    Category = new Category { Name = "Category Name" },
                    Publisher = new ApplicationUser { UserName = "Publisher Name", AboutMe = "Publisher Quote" }
                }
                }.AsQueryable().BuildMock());

            var result = await restaurantService.GetRestaurantDetailsAsync(restaurantId);

            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Test Restaurant"));
            Assert.That(result.ChefsDishName, Is.EqualTo("Special Dish"));
            Assert.That(result.City, Is.EqualTo("City Name"));
            Assert.That(result.CuisineName, Is.EqualTo("Cuisine Name"));
            Assert.That(result.Publisher, Is.EqualTo("Publisher Name"));
        }
        [Test]
        public async Task EditRestaurantAsync_InvalidRestaurantId_ReturnsFalse()
        {
            var invalidRestaurantId = Guid.NewGuid();
            var model = new RestaurantAddViewModel
            {
                Name = "Updated Name",
                City = "Updated City",
                CuisineName = "Updated Cuisine"
            };

            restaurantRepositoryMock
                .Setup(r => r.GetByIdAsync(invalidRestaurantId))
                .ReturnsAsync((Restaurant?)null);

            var result = await restaurantService.EditRestaurantAsync(model, invalidRestaurantId, Guid.NewGuid(), null, null);

            Assert.IsFalse(result);
            restaurantRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Restaurant>()), Times.Never);
        }

       
    }
}

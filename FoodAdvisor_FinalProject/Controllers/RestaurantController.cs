using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
    public class RestaurantController : BaseController 
    {
        private readonly FoodAdvisorDbContext dbContext;
		private readonly IRestaurantService restaurantService;
        public RestaurantController(FoodAdvisorDbContext _dbContext, IRestaurantService restaurantService)
        {
            this.dbContext = _dbContext;
			this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
			IEnumerable<RestaurantIndexViewModel> allRestaurants = await this.restaurantService
				 .IndexGetAllRestaurants();

            return View(allRestaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new RestaurantAddViewModel();
            model.Categories = await GetCategories();
			model.Cities = await GetCities();

			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Add(RestaurantAddViewModel model)
		{

			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategories();
				model.Cities = await GetCities();
				return View(model);
			}

			Restaurant place = new Restaurant()
			{
				Name = model.Name,
				Description = model.Description,
				ImageURL = model.ImageURL,
				CategoryId = model.CategoryId,
				PublisherId = Guid.Parse(GetCurrentUserId()),
				CityId = model.CityId,
                Address = model.Address,
			};

			await this.dbContext.Restaurants.AddAsync(place);
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));

		}

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid restaurantGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

			RestaurantDetailsViewModel? model = await this.restaurantService
				.GetRestaurantDetailsAsync(restaurantGuid);

            if (model == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
        {
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantDeleteViewModel? model = await this.restaurantService
				.DeleteRestaurantViewAsync(restaurantGuid);

			return View(model);
        }
        [HttpPost]
		public async Task<IActionResult> Delete(RestaurantDeleteViewModel model)
        {
			await this.restaurantService
				.DeleteRestaurantAsync(model);

			return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				//if the Guid(Id) is not valid, redirecting to index page
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantAddViewModel? model = await dbContext
				.Restaurants
				.Where(r => r.Id == restaurantGuid && r.IsDeleted == false)
				.AsNoTracking()
				.Select(g => new RestaurantAddViewModel()
				{
					Name = g.Name,
					Description = g.Description,
					ImageURL = g.ImageURL,
					Address = g.Address

				})
				.FirstOrDefaultAsync();

			model.Categories = await GetCategories();
			model.Cities = await GetCities();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RestaurantAddViewModel model, string id)
		{
			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategories();
				model.Cities = await GetCities();
				return View(model);
			}

			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				//if the Guid(Id) is not valid, redirecting to index page
				return this.RedirectToAction(nameof(Index));
			}

			Restaurant? editedRestaurant = await this.dbContext
				.Restaurants
				.FindAsync(restaurantGuid);

			if (editedRestaurant == null && editedRestaurant.IsDeleted == true)
			{
				throw new ArgumentException("Invalid ID");
			}

			editedRestaurant.Name = model.Name;
			editedRestaurant.Address = model.Address;
			editedRestaurant.ImageURL = model.ImageURL;
			editedRestaurant.CategoryId = model.CategoryId;
			editedRestaurant.PublisherId = Guid.Parse(GetCurrentUserId()) ;
			editedRestaurant.Description = model.Description;
			editedRestaurant.CityId = model.CityId;

			await this.dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		

		//TODO: 
		private async Task<List<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }
		private async Task<List<City>> GetCities()
		{
			return await dbContext.Cities.ToListAsync();
		}


	}
}

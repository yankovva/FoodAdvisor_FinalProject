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
			string? userId = this.GetCurrentUserId();


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
			Guid userId = Guid.Parse(GetCurrentUserId());

			await this.restaurantService.AddRestaurantAsync(model, userId);

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
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantAddViewModel? model = await this.restaurantService
				.EditRestaurantViewAsync(restaurantGuid);

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
				return this.RedirectToAction(nameof(Index));
			}
			Guid userGuid = Guid.Parse(GetCurrentUserId());
			
			await this.restaurantService
				.EditRestaurantAsync(model,restaurantGuid,userGuid);

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

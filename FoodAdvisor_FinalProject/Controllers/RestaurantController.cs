using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using FoodAdvisor.ViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
		private readonly IManagerService managerService;
		
		public RestaurantController(FoodAdvisorDbContext _dbContext, 
			IRestaurantService restaurantService,
			IManagerService managerService)
        {
            this.dbContext = _dbContext;
			this.restaurantService = restaurantService;
			this.managerService = managerService;

		}

		public async Task<IActionResult> Index(FilterIndexRestaurantViewModel model)
		{

			IEnumerable<RestaurantIndexViewModel> restaurants =
			   await this.restaurantService.IndexGetAllRecepiesAsync(model);

			int recipeCount = await this.restaurantService.GetFilteredRestaurantsCountAsync(model);


			FilterIndexRestaurantViewModel viewModel = new FilterIndexRestaurantViewModel
			{
				Restaurants = restaurants,
				SearchQuery = model.SearchQuery,
				CategoryFilter = model.CategoryFilter,
				CityFilter = model.CityFilter,
				CuisineFilter = model.CuisineFilter,
				AllCategories = await this.restaurantService.GetAllCategoriesAsync(),
				AllCities = await this.restaurantService.GetAllCitiesAsync(),
				AllCuisines = await this.restaurantService.GetAllCuisinesAsync(),
				CurrentPage = model.CurrentPage,
				EntitiesPerPage = model.EntitiesPerPage,
				TotalPages = (int)Math.Ceiling((double)recipeCount /
											   model.EntitiesPerPage!.Value)
			};

			return View(viewModel);

		}

		[HttpGet]
        public async Task<IActionResult> Add()
        {
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync (userId!);
			if (!isManager)
			{
				//TODO: Add some messages;
				return RedirectToAction(nameof(Index));
			}
			var model = new RestaurantAddViewModel();
            model.Categories = await GetCategories();
			

			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Add(RestaurantAddViewModel model, IFormFile file, IFormFile fileDish)
		{
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategories();
				return View(model);
			}

			await this.restaurantService.AddRestaurantAsync(model, Guid.Parse(userId!),file, fileDish);

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
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

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
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			bool isDeleted = await this.restaurantService
				.DeleteRestaurantAsync(model);
			if (isDeleted == false)
			{
				//TODO: ADD MESSAGE
				return View(model);
			}

			return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantAddViewModel? model = await this.restaurantService
				.EditRestaurantViewAsync(restaurantGuid);

			if (model == null)
			{
				return this.RedirectToAction(nameof(Index));
			}

			model.Categories = await GetCategories();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RestaurantAddViewModel model, string id, IFormFile file, IFormFile fileDish)
		{
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategories();
				return View(model);
			}
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}
			Guid userGuid = Guid.Parse(GetCurrentUserId());
			
			bool isEdited=await this.restaurantService
				.EditRestaurantAsync(model,restaurantGuid,userGuid,file, fileDish);
			if (isEdited == false)
			{
				// TODO: ADD MESSAGE
				return View(model);
			}
			return RedirectToAction(nameof(Index));
		}


		//TODO: 
		private async Task<List<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }
		


	}
}

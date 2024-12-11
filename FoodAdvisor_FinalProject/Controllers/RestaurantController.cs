using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ErrorMessages;

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

		[HttpGet]
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
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}

			bool isManager = await this.managerService
				.IsUserManagerAsync (userId.ToString());
			if (!isManager)
			{
				TempData[ErrorMessage] = NotManagerErrorMessage;
				return RedirectToAction(nameof(Index));
			}
			var model = new RestaurantAddViewModel();
            model.Categories = await GetCategories();
			
			return View(model);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(RestaurantAddViewModel model, IFormFile file, IFormFile fileDish)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId.ToString());
			if (!isManager)
			{
				TempData[ErrorMessage] = NotManagerErrorMessage;
				return RedirectToAction(nameof(Index));
			}
			try
			{
				if (ModelState.IsValid == false)
				{
					model.Categories = await GetCategories();
					TempData[ErrorMessage] = InvalidModelStateErrorMessage;
					return View(model);
				}
				TempData[SuccessMessage] = AddingWasSuccesfullMessage;
				await this.restaurantService
					.AddRestaurantAsync(model, userId, file, fileDish);
			}
			catch (ArgumentException ex)
			{
				TempData[ErrorMessage] = ex.Message;
			}
			

			return RedirectToAction(nameof(Index));

		}

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid restaurantGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
            if (!isGuidValid)
            {
				TempData[ErrorMessage] = InvalidGuidMessage;
				return this.RedirectToAction(nameof(Index));
            }

			RestaurantDetailsViewModel? model = await this.restaurantService
				.GetRestaurantDetailsAsync(restaurantGuid);

            if (model == null)
            {
				TempData[ErrorMessage] = EntityNotFoundMessage;
				return this.RedirectToAction(nameof(Index));
            }

            return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
        {
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId.ToString());
			if (!isManager)
			{
				TempData[ErrorMessage] = NotManagerErrorMessage;
				return RedirectToAction(nameof(Index));
			}

			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				TempData[ErrorMessage] = InvalidGuidMessage;
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantDeleteViewModel? model = await this.restaurantService
				.DeleteRestaurantViewAsync(restaurantGuid);

			return View(model);
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(RestaurantDeleteViewModel model)
        {
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId.ToString());
			if (!isManager)
			{
				TempData[ErrorMessage] = NotManagerErrorMessage;
				return RedirectToAction(nameof(Index));
			}


			bool isDeleted = await this.restaurantService
				.DeleteRestaurantAsync(model);
			if (isDeleted == false)
			{
				TempData[ErrorMessage] = EntityNotFoundMessage;
				return View(model);
			}
			TempData[SuccessMessage] = DeletingWasSuccesfullMessage;
			return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId.ToString());
			if (!isManager)
			{
				TempData[ErrorMessage] = NotManagerErrorMessage;
				return RedirectToAction(nameof(Index));
			}

			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantAddViewModel? model = await this.restaurantService
				.EditRestaurantViewAsync(restaurantGuid);

			if (model == null)
			{
				TempData[ErrorMessage] = EntityNotFoundMessage;
				return this.RedirectToAction(nameof(Index));
			}

			model.Categories = await GetCategories();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(RestaurantAddViewModel model, string id, IFormFile file, IFormFile fileDish)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId.ToString());
			if (!isManager)
			{
				TempData[ErrorMessage] = NotManagerErrorMessage;
				return RedirectToAction(nameof(Index));
			}
			try
			{
				if (ModelState.IsValid == false)
				{
					model.Categories = await GetCategories();
					TempData[ErrorMessage] = InvalidModelStateErrorMessage;
					return View(model);
				}
				Guid restaurantGuid = Guid.Empty;
				bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
				if (!isGuidValid)
				{
					TempData[ErrorMessage] = InvalidGuidMessage;
					return this.RedirectToAction(nameof(Index));
				}

				bool isEdited = await this.restaurantService
					.EditRestaurantAsync(model, restaurantGuid, userId, file, fileDish);
				if (isEdited == false)
				{
					TempData[ErrorMessage] = EntityNotFoundMessage;
					return View(model);
				}
				TempData[SuccessMessage] = EditingWasSuccesfullMessage;
				return RedirectToAction(nameof(Index));
			}
			catch (ArgumentException ex)
			{
				TempData[ErrorMessage] = ex.Message;
				throw;
			}
			
		}


		//TODO: 
		private async Task<List<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }
		


	}
}

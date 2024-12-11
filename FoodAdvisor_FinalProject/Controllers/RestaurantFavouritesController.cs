using FoodAdvisor.Common;
using FoodAdvisor.Data;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RestaurantFavouritesViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Common.ErrorMessages;

namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
	public class RestaurantFavouritesController : BaseController
	{
		private readonly IRestaurantFavouritesService favouritesService;


		public RestaurantFavouritesController(IRestaurantFavouritesService favouritesService)
		{
			this.favouritesService = favouritesService;
		}

		[HttpGet]
		public async Task<IActionResult> Index(RestaurantFavouriteFilteredViewModel model)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}

			IEnumerable<RestaurantFavouritesIndexViewModel> favourites = await this.favouritesService
				.InedexGetAllFavouritesAsync(userId .ToString(), model);

			int restaurantCount = await this.favouritesService
				.GetFilteredRestaurantsCountAsync(userId.ToString(),model);

			RestaurantFavouriteFilteredViewModel viewModel = new RestaurantFavouriteFilteredViewModel
			{
				Restaurants = favourites,
				SearchQuery = model.SearchQuery,
				CategoryFilter = model.CategoryFilter,
				CityFilter = model.CityFilter,
				CuisineFilter = model.CuisineFilter,
				AllCategories = await this.favouritesService.GetAllCategoriesAsync(),
				AllCities = await this.favouritesService.GetAllCitiesAsync(),
				AllCuisines = await this.favouritesService.GetAllCuisinesAsync(),
				CurrentPage = model.CurrentPage,
				EntitiesPerPage = model.EntitiesPerPage,
				TotalPages = (int)Math.Ceiling((double)restaurantCount /
											   model.EntitiesPerPage!.Value)
			};

			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> AddToFavourites(string? id)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			try
			{
				bool isAdded = await this.favouritesService
				.AddToFavouritesAsync(userId, id!);
				if (!isAdded)
				{
					TempData[ErrorMessage] = EntityNotFoundMessage;
					return RedirectToAction(nameof(Index));
				}
				TempData[SuccessMessage] = FavoritesSuccessMessage;
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData[InfoMessage] = ex.Message;
				return RedirectToAction("Index", "Restaurant");
			}
			
		}


		public async Task<IActionResult> RemoveFromFavourites(string? restaurantId)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			bool isDeleted = await this.favouritesService
				.RemoveFromFavouritesAsync(userId, restaurantId!);
			if (!isDeleted)
			{
				TempData[ErrorMessage] = EntityNotFoundMessage;
				return this.RedirectToAction(nameof(Index));
			}
			TempData[SuccessMessage] = FavoritesRemoveSuccessMessage;
			return this.RedirectToAction(nameof(Index));
		}

	}
}


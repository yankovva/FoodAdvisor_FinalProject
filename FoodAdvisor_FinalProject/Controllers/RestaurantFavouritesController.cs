using FoodAdvisor.Common;
using FoodAdvisor.Data;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
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
		public async Task<IActionResult> Index()
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}

			IEnumerable<RestaurantFavouritesIndexViewModel> favourites = await this.favouritesService
				.InedexGetAllFavouritesAsync(userId .ToString());

			return View(favourites);
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


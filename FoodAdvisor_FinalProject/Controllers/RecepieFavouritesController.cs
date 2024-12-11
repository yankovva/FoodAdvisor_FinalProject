using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Common.ErrorMessages;

namespace FoodAdvisor_FinalProject.Controllers
{
    [Authorize]
	public class RecepieFavouritesController : BaseController
	{
		private readonly IRecepieFavouritesService recepieFavouritesService;
        public RecepieFavouritesController(IRecepieFavouritesService recepieFavouritesService)
        {
				this.recepieFavouritesService = recepieFavouritesService;
        }
		[HttpGet]
        public async Task<IActionResult> Index(RecipeFavouritesFilteredViewModel model)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}

			IEnumerable<RecepieFavouritesIndexViewModel> favourites = await this.recepieFavouritesService
				.InedexGetAllFavouritesAsync(userId.ToString(), model);

			int recipeCount = await this.recepieFavouritesService
				.GetFilteredRecepiesCountAsync(userId.ToString(),model);

			RecipeFavouritesFilteredViewModel viewModel = new RecipeFavouritesFilteredViewModel
			{
				Recipes = favourites,
				SearchQuery = model.SearchQuery,
				CategoryFilter = model.CategoryFilter,
				DificultyFilter = model.DificultyFilter,
				AllCategories = await this.recepieFavouritesService.GetAllCategoriesAsync(),
				AllDificulties = await this.recepieFavouritesService.GetAllDificultiesAsync(),
				CurrentPage = model.CurrentPage,
				EntitiesPerPage = model.EntitiesPerPage,
				TotalPages = (int)Math.Ceiling((double)recipeCount /
											   model.EntitiesPerPage!.Value)
			};

			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddToFavourites(string id)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			try
			{
				bool isAdded = await this.recepieFavouritesService
				.AddToFavouritesAsync(userId, id!);

				if (!isAdded)
				{
					TempData[ErrorMessage] = EntityNotFoundMessage;
					return RedirectToAction("Index", "Recepie");
				}

				TempData[SuccessMessage] = FavoritesSuccessMessage;
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData[InfoMessage] = ex.Message;
				return RedirectToAction("Index", "Recepie");
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RemoveFromFavourites(string id)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}

			bool isDeleted = await this.recepieFavouritesService
				.RemoveFromFavouritesAsync(userId, id!);

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

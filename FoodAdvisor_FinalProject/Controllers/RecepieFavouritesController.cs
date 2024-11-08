using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdvisor_FinalProject.Controllers
{
	public class RecepieFavouritesController : BaseController
	{
		private readonly IRecepieFavouritesService recepieFavouritesService;
        public RecepieFavouritesController(IRecepieFavouritesService recepieFavouritesService)
        {
				this.recepieFavouritesService = recepieFavouritesService;
        }
        public async Task<IActionResult> Index()
		{
			string userId = GetCurrentUserId()!;
			if (string.IsNullOrEmpty(userId))
			{
				return RedirectToPage("/Identity/Account/Login");
			}
			

			IEnumerable<RecepieFavouritesIndexViewModel> favourites = await this.recepieFavouritesService
				.InedexGetAllFavouritesAsync(userId);

			return View(favourites);
		}
	}
}

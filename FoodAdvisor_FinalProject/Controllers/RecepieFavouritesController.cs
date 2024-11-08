using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		[HttpPost]
		public async Task<IActionResult> AddToFavourites(string id)
		{
            Guid userguId = Guid.Parse(GetCurrentUserId()!);

            bool isAdded = await this.recepieFavouritesService
                .AddToFavouritesAsync(userguId, id!);

            if (!isAdded)
            {
                //TODO: Add some message
                return RedirectToAction(nameof(Index));
            }
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> RemoveFromFavourites(string id)
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);
			bool isDeleted = await this.recepieFavouritesService
				.RemoveFromFavouritesAsync(userguid, id!);

			if (!isDeleted)
			{
				//TODO: Add some message
				return this.RedirectToAction(nameof(Index));
			}
			return this.RedirectToAction(nameof(Index));
		}
	}
}

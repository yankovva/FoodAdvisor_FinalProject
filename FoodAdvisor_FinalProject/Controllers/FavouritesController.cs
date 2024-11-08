using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
	public class FavouritesController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly IFavouritesService favouritesService;


		public FavouritesController(FoodAdvisorDbContext dbContext,
			IFavouritesService favouritesService)
		{
			this.dbContext = dbContext;
			this.favouritesService = favouritesService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			string userId = GetCurrentUserId()!;
			if (string.IsNullOrEmpty(userId))
			{
				return RedirectToPage("/Identity/Account/Login");
			}

			IEnumerable<FavouritesIndexViewModel> favourites = await this.favouritesService
				.InedexGetAllFavouritesAsync(userId);

			return View(favourites);
		}
		[HttpPost]
		public async Task<IActionResult> AddToFavourites(string? restaurantId)
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);
			bool isAdded = await this.favouritesService
				.AddToFavouritesAsync(userguid, restaurantId!);
			if (!isAdded)
			{
				//TODO: Add some message
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> RemoveFromFavourites(string? restaurantId)
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);
			bool isDeleted = await this.favouritesService
				.RemoveFromFavouritesAsync(userguid, restaurantId!);
			if (!isDeleted)
			{
				//TODO: Add some message
				return this.RedirectToAction(nameof(Index));
			}
			return this.RedirectToAction(nameof(Index));
		}

	}
}


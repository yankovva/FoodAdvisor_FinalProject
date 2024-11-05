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
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IFavouritesService favouritesService;


		public FavouritesController(FoodAdvisorDbContext dbContext,
			UserManager<ApplicationUser> userManager,
			IFavouritesService favouritesService)
		{
			this.dbContext = dbContext;
			this.userManager = userManager;
			this.favouritesService = favouritesService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			string? userId = userManager.GetUserId(User)!;

			//if (string.IsNullOrEmpty(userId))
			//{
			//    return RedirectToRoute("/Identity/Account/Login");
			//}

			IEnumerable<FavouritesIndexViewModel> favourites = await this.favouritesService
				.InedexGetAllFavouritesAsync(userId);

			return View(favourites);
		}
		[HttpPost]
		public async Task<IActionResult> AddToFavourites(string? id)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}
			Guid userguid = Guid.Parse(this.userManager.GetUserId(User)!);

			await this.favouritesService
				.AddToFavouritesAsync(userguid, restaurantGuid);

			return RedirectToAction(nameof(Index));

		}


		public async Task<IActionResult> RemoveFromFavourites(string? id)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				//if the Guid(Id) is not valid, redirecting to index page
				return this.RedirectToAction(nameof(Index));
			}
			Guid userguid = Guid.Parse(this.userManager.GetUserId(User)!);

			Restaurant? restaurant = await this.dbContext
				.Restaurants
				.Where(r => r.IsDeleted == false)
				.FirstOrDefaultAsync(r => r.Id == restaurantGuid);

			if (restaurant == null)
			{
				return this.RedirectToAction(nameof(Index));
			}


			UserRestaurant? userRestaurant = await this.dbContext
			  .UsersRestaurants
			  .FirstOrDefaultAsync(ur => ur.ApplicationUserId == userguid && ur.RestaurantId == restaurantGuid);

			if ((userRestaurant == null))
			{
				return this.RedirectToAction(nameof(Index));
			}
			else
			{
				this.dbContext.UsersRestaurants
					.Remove(userRestaurant);

				await this.dbContext.SaveChangesAsync();
			}

			return this.RedirectToAction(nameof(Index));
		}

	}
}


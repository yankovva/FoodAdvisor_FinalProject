﻿using FoodAdvisor.Data;
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
			string userId = GetCurrentUserId();

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
			Guid userguid = Guid.Parse(GetCurrentUserId());

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
				return this.RedirectToAction(nameof(Index));
			}
			Guid userguid = Guid.Parse(GetCurrentUserId());
			
			await this.favouritesService
				.RemoveFromFavouritesAsync(userguid, restaurantGuid);

			return this.RedirectToAction(nameof(Index));
		}

	}
}


using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using static FoodAdvisor.Infrastructure.ClaimsPrincipalExtension;


namespace FoodAdvisor_FinalProject.Controllers
{
	public class RecepieController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly IRecepieService recepieService;
		private readonly IManagerService managerService;
		private readonly IWebHostEnvironment enviorment;
		private readonly IRecepieFavouritesService recepieFavouritesService;


		public RecepieController(FoodAdvisorDbContext dbContext,
			IRecepieService recepieService,
			IManagerService managerService,
			IRecepieFavouritesService recepieFavouritesService)
		{
			this.dbContext = dbContext;
			this.recepieService = recepieService;
			this.managerService = managerService;
			this.recepieFavouritesService = recepieFavouritesService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			RecepiePaginationIndexViewModel model = await recepieService.IndexGetAllRecepiesAsync(1);

            return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(int index)
		{
            RecepiePaginationIndexViewModel viewmodel = await recepieService.IndexGetAllRecepiesAsync(index);

			return View(viewmodel);
        }

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			string? userId = this.GetCurrentUserId();
			AddRecepieViewModel model = new AddRecepieViewModel();
			model.Categories = await GetCategories();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddRecepieViewModel model, IFormFile file)
		{
			string? userId = this.GetCurrentUserId();

			if (!ModelState.IsValid)
			{
				model.Categories = await GetCategories();
				return View(model);
			}

			await this.recepieService.AddRecepiesAsync(model, Guid.Parse(userId!),file);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref recepieGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			DetailsRecepieViewModel model = await this.recepieService
				.GetRecepietDetailsAsync(recepieGuid);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref recepieGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}
			DeleteRecepieViewModel model = await this.recepieService
				.DeleteRecepieViewAsync(recepieGuid);
			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> Delete(DeleteRecepieViewModel model)
		{
			bool isDeleted = await this.recepieService
				.DeleteRecepieAsync(model);
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
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref recepieGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			AddRecepieViewModel model = await this.recepieService
				.EditRecepieViewAsync (recepieGuid);
			model.Categories = await GetCategories();


			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AddRecepieViewModel model, string id, IFormFile file)
		{
			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategories();
				return View(model);
			}

			Guid userGuid = Guid.Parse(GetCurrentUserId());

			bool isUpdated = await this.recepieService
				.EditRecepieAsync(model,id, userGuid,file);

			if (isUpdated == false)
			{
				//TODO: ADD MESSAGE
				return View(model);
			}

			return RedirectToAction(nameof(Index));
		}


		private async Task<List<RecepieCategory>> GetCategories()
		{
			return await dbContext.RecepiesCategories.ToListAsync();
		}

		
	}
}

using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ErrorMessages;


namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
	public class RecepieController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly IRecepieService recepieService;
		private readonly IManagerService managerService;
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
		public async Task<IActionResult> Index(FilterIndexRecipeViewModel model)
		{
			IEnumerable<RecepieIndexViewModel> recipes =
			   await this.recepieService.IndexGetAllRecepiesAsync(model);

			int recipeCount = await this.recepieService.GetFilteredRecepiesCountAsync(model);

			FilterIndexRecipeViewModel viewModel = new FilterIndexRecipeViewModel
			{
				Recipes = recipes,
				SearchQuery = model.SearchQuery,
				CategoryFilter = model.CategoryFilter,
				DificultyFilter = model.DificultyFilter,
				AllCategories = await this.recepieService.GetAllCategoriesAsync(),
				AllDificulties = await this.recepieService.GetAllDificultiesAsync(),
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
			AddRecepieViewModel model = new AddRecepieViewModel();
			model.Categories = await GetCategories();
			model.Dificulty = await GetDificulty();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(AddRecepieViewModel model, IFormFile file)
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			if (!ModelState.IsValid)
			{
				model.Categories = await GetCategories();
				model.Dificulty = await GetDificulty();
				TempData[SuccessMessage] = InvalidModelStateErrorMessage;
				return View(model);			
			}

			await this.recepieService.AddRecepiesAsync(model, userId,file);
			TempData[SuccessMessage] = AddingWasSuccesfullMessage;
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id)
		{
			try
			{
				DetailsRecepieViewModel model = await this.recepieService
				.GetRecepietDetailsAsync(id);

				if (model == null)
				{
					TempData[ErrorMessage] = EntityNotFoundMessage;
					return RedirectToAction(nameof(Index));
				}

				return View(model);
			}
			catch (ArgumentException ex)
			{
				TempData[ErrorMessage] = ex.Message; ;
				return RedirectToAction(nameof(Index));
			}
			
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			DeleteRecepieViewModel model = null!;
			try
			{
				 model = await this.recepieService
				.DeleteRecepieViewAsync(id);
			}
			catch (ArgumentException ex)
			{
				TempData[ErrorMessage] = ex.Message;
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(DeleteRecepieViewModel model)
		{
			bool isDeleted = await this.recepieService
				.DeleteRecepieAsync(model);
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
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref recepieGuid);
			if (!isGuidValid)
			{
				TempData[ErrorMessage] = InvalidGuidMessage;
				return this.RedirectToAction(nameof(Index));
			}

			AddRecepieViewModel model = await this.recepieService
				.EditRecepieViewAsync (recepieGuid);
			if (model == null)
			{
				TempData[ErrorMessage] = EntityNotFoundMessage;
				return this.RedirectToAction(nameof(Index));
			}
			model.Categories = await GetCategories();
			model.Dificulty = await GetDificulty();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(AddRecepieViewModel model, string id, IFormFile file)
		{
			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategories();
				model.Dificulty = await GetDificulty();
				TempData[ErrorMessage] = InvalidModelStateErrorMessage;
				return View(model);
			}
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			try
			{
				bool isUpdated = await this.recepieService
			 .EditRecepieAsync(model, id, userId, file);

				if (isUpdated == false)
				{
					TempData[ErrorMessage] = UnexpectedErrorMessage;
					return View(model);
				}
				TempData[ErrorMessage] = EditingWasSuccesfullMessage;
				return RedirectToAction(nameof(Details), new {Id = id});
			}
			catch (ArgumentException ex)
			{
				TempData[ErrorMessage] = ex.Message;
				return RedirectToAction(nameof(Index));
			}
			
		}


		private async Task<List<RecepieCategory>> GetCategories()
		{
			return await dbContext.RecepiesCategories.ToListAsync();
		}

		private async Task<List<RecepieDificulty>> GetDificulty()
		{
			return await dbContext.RecepiesDificulties.ToListAsync();
		}

	}
}

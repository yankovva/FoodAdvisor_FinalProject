using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Infrastructure.ClaimsPrincipalExtension;


namespace FoodAdvisor_FinalProject.Controllers
{
	public class RecepieController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly IRecepieService recepieService;
		private readonly IManagerService managerService;

		public RecepieController(FoodAdvisorDbContext dbContext,
			IRecepieService recepieService,
			IManagerService managerService)
		{
			this.dbContext = dbContext;
			this.recepieService = recepieService;
			this.managerService = managerService;
		}
		public async Task<IActionResult> Index()
		{
			IEnumerable<RecepieIndexViewModel> model = await this.recepieService
				.IndexGetAllRecepiesAsync();
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			AddRecepieViewModel model = new AddRecepieViewModel();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddRecepieViewModel model)
		{
			string? userId = this.GetCurrentUserId();
			bool isManager = await this.managerService
				.IsUserManagerAsync(userId!);
			if (!isManager)
			{
				return RedirectToAction(nameof(Index));
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await this.recepieService.AddRecepiesAsync(model, Guid.Parse(userId!));
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
			if (!isDeleted)
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

			return View(model);
		}
	}
}

using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FoodAdvisor_FinalProject.Controllers
{
	public class RecepieController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly IRecepieService recepieService;

		public RecepieController(FoodAdvisorDbContext dbContext, IRecepieService recepieService)
		{
			this.dbContext = dbContext;
			this.recepieService = recepieService;
		}
		public async Task<IActionResult> Index()
		{
			IEnumerable<RecepieIndexViewModel> model = await this.recepieService
				.IndexGetAllRecepiesAsync();
			return View(model);
		}
	}
}

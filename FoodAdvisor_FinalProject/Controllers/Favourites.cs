using Microsoft.AspNetCore.Mvc;

namespace FoodAdvisor_FinalProject.Controllers
{
	public class Favourites : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

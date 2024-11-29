using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.AccountViemModels;
using FoodAdvisor_FinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodAdvisor_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        public IActionResult Index()
        {
			return View();
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            if (!statusCode.HasValue)
            {
                return this.View();
            }
            else if (statusCode == 404)
            {
                return View("Error404");
            }
            else if(statusCode == 403 || statusCode == 401)
            {
				return View("Error401");
			}

            return View("Error500");

           // return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FoodAdvisor_FinalProject.Controllers
{
    public class RestaurantCommentController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}

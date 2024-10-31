using FoodAdvisor.Data;
using FoodAdvisor.ViewModels.PlaceViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor_FinalProject.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private readonly FoodAdvisorDbContext dbContext;
        public PlaceController(FoodAdvisorDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlaceIndexViewModel> model = await this.dbContext
                .Places
                .Select(p => new PlaceIndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    Address = p.Address,
                    Rating = p.Rating,
                    Publisher = p.Publisher.UserName ?? string.Empty,
                    Category = p.Category.Name

                })
                .AsNoTracking()
                .ToArrayAsync();

            return View(model);
        }
    }
}

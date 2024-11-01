using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
    public class RestaurantController : BaseController 
    {
        private readonly FoodAdvisorDbContext dbContext;
        public RestaurantController(FoodAdvisorDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RestaurantIndexViewModel> model = await this.dbContext
                .Restaurants
				.Select(p => new RestaurantIndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    Category = p.Category.Name
                })
                .AsNoTracking()
                .ToArrayAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new RestaurantAddViewModel();
            model.Categories = await GetCategory();
			model.Cities = await GetCities();

			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Add(RestaurantAddViewModel model)
		{

			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategory();
				model.Cities = await GetCities();
				return View(model);
			}

			Restaurant place = new Restaurant()
			{
				Name = model.Name,
				Description = model.Description,
				ImageURL = model.ImageURL,
				CategoryId = model.CategoryId,
				PublisherId = Guid.Parse(GetCurrentUserId()),
				CityId = model.CityId,
                Address = model.Address,
			};

			await this.dbContext.Restaurants.AddAsync(place);
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));

		}

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid placeGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref placeGuid);
            if (!isGuidValid)
            {
                //if the Guid(Id) is not valid, redirecting to index page
                return this.RedirectToAction(nameof(Index));
            }

			RestaurantDetailsViewModel? model = await dbContext
                .Restaurants
				.Where(p => p.Id == placeGuid)
                .Select(p => new RestaurantDetailsViewModel()
                {
                    Name = p.Name,
                    Description = p.Description,
                    ImageURL = p.ImageURL,
                    Address = p.Address,
                    Category = p.Category.Name,
                    City = p.City.Name,
                    Publisher = p.Publisher.UserName ?? string.Empty

                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return this.RedirectToAction(nameof(Index));
            }


            return View(model);
        }

        private string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		//TODO: 
		private async Task<List<Category>> GetCategory()
        {
            return await dbContext.Categories.ToListAsync();
        }
		private async Task<List<City>> GetCities()
		{
			return await dbContext.Cities.ToListAsync();
		}


	}
}

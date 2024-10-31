using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.PlaceViewModels;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodAdvisor_FinalProject.Controllers
{
    [Authorize]
    public class PlaceController : BaseController 
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
                    Category = p.Category.Name
                })
                .AsNoTracking()
                .ToArrayAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new PlaceAddViewModel();
            model.Categories = await GetCategory();
			model.Cities = await GetCities();

			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Add(PlaceAddViewModel model)
		{

			if (ModelState.IsValid == false)
			{
				model.Categories = await GetCategory();
				model.Cities = await GetCities();
				return View(model);
			}
			
			Place place = new Place()
			{
				Name = model.Name,
				Description = model.Description,
				ImageURL = model.ImageURL,
				CategoryId = model.CategoryId,
				PublisherId = Guid.Parse(GetCurrentUserId()),
				CityId = model.CityId,
                Address = model.Address,
			};

			await this.dbContext.Places.AddAsync(place);
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));

		}

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref movieGuid);
            if (!isGuidValid)
            {
                //if the Guid(Id) is not valid, redirecting to index page
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

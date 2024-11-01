using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
	public class FavouritesController : BaseController
	{
        private readonly FoodAdvisorDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;


        public FavouritesController(FoodAdvisorDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = userManager.GetUserId(User)!;

            //if (string.IsNullOrEmpty(userId))
            //{
            //    return RedirectToRoute("/Identity/Account/Login");
            //}

            IEnumerable<FavouritesIndexViewModel> favourites = await this.dbContext
                .UsersRestaurants
                .Include(ur => ur.Restaurant)
                .Where(ur => ur.Restaurant.IsDeleted == false && ur.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(ur => new FavouritesIndexViewModel()
                {
                    Id = ur.ApplicationUserId.ToString(),
                    Name = ur.Restaurant.Name,
                    Description = ur.Restaurant.Description,
                    Category = ur.Restaurant.Category.Name,
                    ImageUrl = ur.Restaurant.ImageURL ?? string.Empty
                })
                .ToArrayAsync();
                

            return View(favourites);
        }
        [HttpPost]
        public async Task<IActionResult> AddToFavourites(string? id)
        {
            Guid restaurantGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
            if (!isGuidValid)
            {
                //if the Guid(Id) is not valid, redirecting to index page
                return this.RedirectToAction(nameof(Index));
            }

            Restaurant? restaurant = await this.dbContext
                .Restaurants
                .FirstOrDefaultAsync(r => r.Id == restaurantGuid);

            if (restaurant == null)
            {
                return this.RedirectToAction(nameof (Index));
            }

            Guid userguid = Guid.Parse(this.userManager.GetUserId(User)!);

            bool alreaduAddedToFavourites = await this.dbContext
                .UsersRestaurants.AnyAsync(ur => ur.ApplicationUserId == userguid && ur.RestaurantId == restaurantGuid);

            if (!alreaduAddedToFavourites)
            {
                UserRestaurant newFavoriteRestaurant = new UserRestaurant()
                {
                    ApplicationUserId = userguid,
                    RestaurantId = restaurantGuid,
                };

                await this.dbContext.UsersRestaurants.AddAsync(newFavoriteRestaurant);
                await this.dbContext.SaveChangesAsync();
            }

            return this.RedirectToAction(nameof(Index));

        }

    }
}

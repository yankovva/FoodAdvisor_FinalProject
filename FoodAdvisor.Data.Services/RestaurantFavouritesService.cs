using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RestaurantFavouritesViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ErrorMessages;
namespace FoodAdvisor.Data.Services
{
	public class RestaurantFavouritesService : BaseService, IRestaurantFavouritesService
	{
		private IRepository<Restaurant, Guid> restaurantRepository;
		private IRepository<UserRestaurant, object> userRestaurantRepository;


		public RestaurantFavouritesService(IRepository<Restaurant, Guid> restaurantRepository,
			IRepository<UserRestaurant, object> userRestaurantRepository)
		{
			this.restaurantRepository = restaurantRepository;
			this.userRestaurantRepository = userRestaurantRepository;
		}
		public async Task<bool> AddToFavouritesAsync(Guid userId, string restaurantId)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(restaurantId, ref restaurantGuid);
			if (!isGuidValid)
			{
				return false;
			}
			Restaurant? restaurant = await this.restaurantRepository
			   .GetAllAttached()
			   .Where(r => r.IsDeleted == false)
			   .FirstOrDefaultAsync(r => r.Id == restaurantGuid);

			if (restaurant == null)
			{
				return false;
			}

			bool alreaduAddedToFavourites = await this.userRestaurantRepository
				.GetAllAttached()
				.AnyAsync(ur => ur.ApplicationUserId == userId && ur.RestaurantId == restaurantGuid);

			UserRestaurant newFavoriteRestaurant = new UserRestaurant();
			
			if (alreaduAddedToFavourites == true)
			{
				throw new Exception(FavoritesErrorMessage);
			};
			newFavoriteRestaurant.ApplicationUserId = userId;
			newFavoriteRestaurant.RestaurantId = restaurantGuid;

			await this.userRestaurantRepository.AddAsync(newFavoriteRestaurant!);
			return true;

		}

		public async Task<IEnumerable<string>> GetAllCategoriesAsync()
		{
			IEnumerable<string> allCategories = await this.userRestaurantRepository
					.GetAllAttached()
					.Select(c => c.Restaurant.Category.Name)
					.Distinct()
					.ToArrayAsync();

			return allCategories;
		}

		public async Task<IEnumerable<string>> GetAllCitiesAsync()
		{
			IEnumerable<string> allCitites = await this.userRestaurantRepository
					.GetAllAttached()
					.Select(c => c.Restaurant.City.Name)
					.Distinct()
					.ToArrayAsync();

			return allCitites;
		}

		public  async Task<IEnumerable<string>> GetAllCuisinesAsync()
		{
			IEnumerable<string> allCuisines = await this.userRestaurantRepository
					.GetAllAttached()
					.Select(c => c.Restaurant.Cuisine.Name)
					.Distinct()
					.ToArrayAsync();

			return allCuisines;
		}

		public async Task<int> GetFilteredRestaurantsCountAsync(string userId,RestaurantFavouriteFilteredViewModel inputModel)
		{
			RestaurantFavouriteFilteredViewModel model = new RestaurantFavouriteFilteredViewModel()
			{
				CurrentPage = null,
				EntitiesPerPage = null,
				SearchQuery = inputModel.SearchQuery,
				CategoryFilter = inputModel.CategoryFilter,
				CuisineFilter = inputModel.CuisineFilter,
				CityFilter = inputModel.CityFilter
			};

			int restaurantsCount = (await this.InedexGetAllFavouritesAsync(userId,model))
				.Count();

			return restaurantsCount;
		}

		public async Task<IEnumerable<RestaurantFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId, RestaurantFavouriteFilteredViewModel model)
		{
			IQueryable<UserRestaurant> allRestaurants = this.userRestaurantRepository
				.GetAllAttached();

			if (!String.IsNullOrWhiteSpace(model.SearchQuery))
			{
				allRestaurants = allRestaurants
					.Where(m => m.Restaurant.Name.ToLower().Contains(model.SearchQuery.ToLower()));
			}

			if (!String.IsNullOrWhiteSpace(model.CityFilter))
			{
				allRestaurants = allRestaurants
					.Where(m => m.Restaurant.City.Name.ToLower() == model.CityFilter.ToLower());

			}

			if (!String.IsNullOrWhiteSpace(model.CuisineFilter))
			{
				allRestaurants = allRestaurants
					.Where(m => m.Restaurant.Cuisine.Name.ToLower() == model.CuisineFilter.ToLower());
			}
			if (!String.IsNullOrWhiteSpace(model.CategoryFilter))
			{
				allRestaurants = allRestaurants
					.Where(m => m.Restaurant.Category.Name.ToLower() == model.CategoryFilter.ToLower());
			}


			if (model.CurrentPage.HasValue &&
				model.EntitiesPerPage.HasValue)
			{
				allRestaurants = allRestaurants
					.Skip(model.EntitiesPerPage.Value * (model.CurrentPage.Value - 1))
					.Take(model.EntitiesPerPage.Value);

			}

			var favourites = await allRestaurants
				.Where(ur => ur.Restaurant.IsDeleted == false && ur.ApplicationUserId.ToString().ToLower() == userId.ToLower())
			   .Select(ur => new RestaurantFavouritesIndexViewModel()
			   {
				   Id = ur.RestaurantId.ToString(),
				   Name = ur.Restaurant.Name,
				   Description = ur.Restaurant.Description.Substring(0, 120),
				   Category = ur.Restaurant.Category.Name,
				   ImageUrl = ur.Restaurant.ImageURL ?? string.Empty,
				   PriceRange = ur.Restaurant.PriceRange,
				   Location = ur.Restaurant.City.Name
			   })
			   .ToArrayAsync();
			return favourites;
		}

		public async Task<bool> RemoveFromFavouritesAsync(Guid userId, string restaurantId)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(restaurantId, ref restaurantGuid);
			if (!isGuidValid)
			{
				return false;
			}
			Restaurant? restaurant = await this.restaurantRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false)
				.FirstOrDefaultAsync(r => r.Id == restaurantGuid);

			if (restaurant == null)
			{
				return false;
			}

			UserRestaurant? userRestaurant = await this.userRestaurantRepository
			  .FirstorDefaultAsync(ur => ur.ApplicationUserId == userId && ur.RestaurantId == restaurantGuid);

			if (userRestaurant == null)
			{
				return false;
			}

			await this.userRestaurantRepository.DeleteAsync(userRestaurant);
			return true;
		}

	}
}


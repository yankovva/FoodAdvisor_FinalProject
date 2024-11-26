using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			if (alreaduAddedToFavourites == false)
			{
				newFavoriteRestaurant.ApplicationUserId = userId;
				newFavoriteRestaurant.RestaurantId = restaurantGuid;
				
				await this.userRestaurantRepository.AddAsync(newFavoriteRestaurant!);
				return true;
			};

			return false;

		}
		public async Task<IEnumerable<RestaurantFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId)
		{
			IEnumerable<RestaurantFavouritesIndexViewModel> favourites = await this.userRestaurantRepository
				.GetAllAttached()
			   .Where(ur => ur.Restaurant.IsDeleted == false && ur.ApplicationUserId.ToString().ToLower() == userId.ToLower())
			   .Select(ur => new RestaurantFavouritesIndexViewModel()
			   {
				   Id = ur.RestaurantId.ToString(),
				   Name = ur.Restaurant.Name,
				   Description = ur.Restaurant.Description.Substring(0, 120),
				   Category = ur.Restaurant.Category.Name,
				   ImageUrl = ur.Restaurant.ImageURL ?? string.Empty,
				   PriceRange = ur.Restaurant.PricaRange,
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


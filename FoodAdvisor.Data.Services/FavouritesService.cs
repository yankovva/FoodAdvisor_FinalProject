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
	public class FavouritesService : IFavouritesService
	{
		private IRepository<Restaurant, Guid> restaurantRepository;
		private IRepository<UserRestaurant, object> userRestaurantRepository;


		public FavouritesService(IRepository<Restaurant, Guid> restaurantRepository,
			IRepository<UserRestaurant, object> userRestaurantRepository)
		{
			this.restaurantRepository = restaurantRepository;
			this.userRestaurantRepository = userRestaurantRepository;
		}
		public async Task AddToFavouritesAsync(Guid userId, Guid restaurantId)
		{
			Restaurant? restaurant = await this.restaurantRepository
			   .GetAllAttached()
			   .Where(r => r.IsDeleted == false)
			   .FirstOrDefaultAsync(r => r.Id == restaurantId);

			if (restaurant == null)
			{
				throw new ArgumentException("Invalid Id");
			}

			bool alreaduAddedToFavourites = await this.userRestaurantRepository
				.GetAllAttached()
				.AnyAsync(ur => ur.ApplicationUserId == userId && ur.RestaurantId == restaurantId);

			UserRestaurant newFavoriteRestaurant = null;

			if (!alreaduAddedToFavourites)
			{
				 newFavoriteRestaurant = new UserRestaurant()
				{
					ApplicationUserId = userId,
					RestaurantId = restaurantId,
				};
			};

			await this.userRestaurantRepository.AddAsync(newFavoriteRestaurant);

		}
		public async Task<IEnumerable<FavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId)
		{
			IEnumerable<FavouritesIndexViewModel> favourites = await this.userRestaurantRepository
				.GetAllAttached()
			   .Where(ur => ur.Restaurant.IsDeleted == false && ur.ApplicationUserId.ToString().ToLower() == userId.ToLower())
			   .Select(ur => new FavouritesIndexViewModel()
			   {
				   Id = ur.RestaurantId.ToString(),
				   Name = ur.Restaurant.Name,
				   Description = ur.Restaurant.Description,
				   Category = ur.Restaurant.Category.Name,
				   ImageUrl = ur.Restaurant.ImageURL ?? string.Empty
			   })
			   .ToArrayAsync();
			return favourites;
		}

		public async Task RemoveFromFavouritesAsync(Guid userId, Guid restaurantId)
		{
			Restaurant? restaurant = await this.restaurantRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false)
				.FirstOrDefaultAsync(r => r.Id == restaurantId);

			if (restaurant == null)
			{
				throw new ArgumentException("Invalid Id");
			}

			UserRestaurant? userRestaurant = await this.userRestaurantRepository
			  .GetAllAttached()
			  .FirstOrDefaultAsync(ur => ur.ApplicationUserId == userId && ur.RestaurantId == restaurantId);

			if (userRestaurant != null)
			{
				await this.userRestaurantRepository.DeleteAsync(userRestaurant);
			}
		}

		}
	}


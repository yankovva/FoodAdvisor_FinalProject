using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
	public class FavouritesService : IFavouritesService
	{
		public Task AddToFavouritesAsync(string userId, string restaurantId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FavouritesIndexViewModel>> InedexGetAllFavouritesAsync()
		{
			throw new NotImplementedException();
		}

		public bool IsGuidValid(string? id, ref Guid parsedGuid)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromFavouritesAsync(string userId, string restaurantId)
		{
			throw new NotImplementedException();
		}
	}
}

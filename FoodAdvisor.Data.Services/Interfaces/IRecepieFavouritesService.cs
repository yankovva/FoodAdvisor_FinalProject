using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRecepieFavouritesService
	{
		Task<IEnumerable<RecepieFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId);
		Task<bool> AddToFavouritesAsync(Guid userId, string entityId);
		Task<bool> RemoveFromFavouritesAsync(Guid userId, string entityId);
	}
}

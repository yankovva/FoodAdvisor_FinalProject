using FoodAdvisor.ViewModels.FavouritesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
    public interface IRestaurantFavouritesService 
    {
        Task<IEnumerable<RestaurantFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId);
		Task<bool> AddToFavouritesAsync(Guid userId ,string entityId);
        Task<bool> RemoveFromFavouritesAsync(Guid userId,string entityId);

	}
}

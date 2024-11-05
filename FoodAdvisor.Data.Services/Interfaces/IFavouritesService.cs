using FoodAdvisor.ViewModels.FavouritesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
    public interface IFavouritesService : IBaseService
    {
        Task<IEnumerable<FavouritesIndexViewModel>> InedexGetAllFavouritesAsync();
		Task AddToFavouritesAsync(string userId ,string restaurantId);
        Task RemoveFromFavouritesAsync(string userId,string restaurantId);

	}
}

using FoodAdvisor.ViewModels.FavouritesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
    public interface IFavouritesService 
    {
        Task<IEnumerable<FavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId);
		Task AddToFavouritesAsync(Guid userId ,Guid restaurantId);
        Task RemoveFromFavouritesAsync(Guid userId,Guid restaurantId);

	}
}

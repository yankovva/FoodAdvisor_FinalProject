using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RestaurantFavouritesViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRestaurantFavouritesService 
    {
        Task<IEnumerable<RestaurantFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId, RestaurantFavouriteFilteredViewModel model);
		Task<bool> AddToFavouritesAsync(Guid userId ,string entityId);
        Task<bool> RemoveFromFavouritesAsync(Guid userId,string entityId);
		Task<IEnumerable<string>> GetAllCitiesAsync();
		Task<int> GetFilteredRestaurantsCountAsync(string userId, RestaurantFavouriteFilteredViewModel inputModel);
		Task<IEnumerable<string>> GetAllCategoriesAsync();
		Task<IEnumerable<string>> GetAllCuisinesAsync();

	}
}

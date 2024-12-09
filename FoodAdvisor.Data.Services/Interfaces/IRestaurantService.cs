using FoodAdvisor.ViewModels.RecepiesViewModels;
using FoodAdvisor.ViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRestaurantService 
	{
		Task<IEnumerable<RestaurantIndexViewModel>> IndexGetAllRecepiesAsync(FilterIndexRestaurantViewModel model);
		Task AddRestaurantAsync(RestaurantAddViewModel model, Guid userId, IFormFile file, IFormFile fileDish);
		Task<RestaurantDetailsViewModel> GetRestaurantDetailsAsync(Guid restaurnatId);

		Task<RestaurantDeleteViewModel> DeleteRestaurantViewAsync(Guid id);
		Task<bool> DeleteRestaurantAsync(RestaurantDeleteViewModel model);
		Task<bool> EditRestaurantAsync(RestaurantAddViewModel model,Guid restaurantId, Guid userId, IFormFile file, IFormFile fileDish);
		Task<RestaurantAddViewModel> EditRestaurantViewAsync(Guid id);

		Task<IEnumerable<string>> GetAllCitiesAsync();
		Task<int> GetFilteredRestaurantsCountAsync(FilterIndexRestaurantViewModel inputModel);
		Task<IEnumerable<string>> GetAllCategoriesAsync();
		Task<IEnumerable<string>> GetAllCuisinesAsync();
	}
}

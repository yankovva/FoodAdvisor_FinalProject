﻿using FoodAdvisor.ViewModels.RestaurantViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRestaurantService 
	{
		Task<IEnumerable<RestaurantIndexViewModel>> IndexGetAllRestaurants();

		Task AddRestaurantAsync(RestaurantAddViewModel model);
		Task<RestaurantDetailsViewModel> GetRestaurantDetailsAsync(Guid id);

		Task<RestaurantDeleteViewModel> DeleteRestaurantViewAsync(Guid id);
		Task DeleteRestaurantAsync(RestaurantDeleteViewModel model);
		Task<RestaurantAddViewModel> EditRestaurantasync(Guid id);
	}
}
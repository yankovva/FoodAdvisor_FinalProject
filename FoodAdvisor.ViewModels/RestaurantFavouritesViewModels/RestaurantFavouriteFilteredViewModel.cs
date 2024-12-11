﻿using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RestaurantFavouritesViewModels
{
	public class RestaurantFavouriteFilteredViewModel
	{
		public IEnumerable<RestaurantFavouritesIndexViewModel>? Restaurants { get; set; }

		public string? SearchQuery { get; set; }

		public string? CategoryFilter { get; set; }

		public IEnumerable<string>? AllCategories { get; set; }

		public string? CuisineFilter { get; set; }

		public IEnumerable<string>? AllCuisines { get; set; }
		public string? CityFilter { get; set; }

		public IEnumerable<string>? AllCities { get; set; }

		public int? CurrentPage { get; set; } = 1;

		public int? EntitiesPerPage { get; set; } = 16;

		public int? TotalPages { get; set; }
	}
}

using FoodAdvisor.ViewModels.RecepiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
	public class RestaurantPaginatonIndexViewModel
	{
		public int CurrentPageIndex { get; set; }

		public int PageCount { get; set; }

		public IEnumerable<RestaurantIndexViewModel> Restaurants { get; set; } = new List<RestaurantIndexViewModel>();
	}
}

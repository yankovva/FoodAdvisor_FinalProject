using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
    public class RestaurantIndexViewModel
	{
        public required string Id { get; set; }
        public required string Name { get; set; } 
        public string? ImageURL { get; set; }
		public required string Publisher { get; set; } 
        public required string Category { get; set; }
		public required string PriceRange { get; set; }
        public required string City { get; set; } 


    }
}

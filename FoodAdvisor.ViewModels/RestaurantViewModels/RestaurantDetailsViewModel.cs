using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
    public class RestaurantDetailsViewModel
	{
        public required string Name { get; set; }
        public string? ImageURL { get; set; }
        public required string Description { get; set; }
        public required string Publisher { get; set; }
        public required string Category { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
    }
}

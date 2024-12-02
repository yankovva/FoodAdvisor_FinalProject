using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.FavouritesViewModel
{
    public class RestaurantFavouritesIndexViewModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required string Category { get; set; }
		public required int PriceRange { get; set; }
		public required string Location { get; set; }

	}
}

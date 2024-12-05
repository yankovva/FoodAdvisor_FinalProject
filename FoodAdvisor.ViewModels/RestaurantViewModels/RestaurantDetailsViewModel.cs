using FoodAdvisor.ViewModels.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
    public class RestaurantDetailsViewModel
	{
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? ImageURL { get; set; }
		public string? ChefsDishImage { get; set; }
		public required string ChefsDishName { get; set; }
		public required string Description { get; set; }
		public required string MenuDescription { get; set; }
		public required string AtmosphereDescription { get; set; }
		public required string Publisher { get; set; }
		public required string PublisherId { get; set; }
		public required string PublisherQuote { get; set; }
		public required string Category { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
		public required int PriceRange { get; set; }
		public required string CuisineName { get; set; }
		public required int Likes { get; set; }

		public IEnumerable<CommentAllViewModel> AllComment { get; set; } = new List<CommentAllViewModel>(); 
    }
}

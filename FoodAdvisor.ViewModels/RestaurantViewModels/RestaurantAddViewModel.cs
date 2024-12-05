using FoodAdvisor.Data.Models;
using System.ComponentModel.DataAnnotations;
using static FoodAdvisor.Common.EntityValidationConstants.City;
using static FoodAdvisor.Common.EntityValidationConstants.Restaurant;
using static FoodAdvisor.Common.EntityValidationConstants.Cuisine;



namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
	public class RestaurantAddViewModel
	{
		[MaxLength(NameMaxLenght)]
		[MinLength(NameMinLenght)]
		[Required]
		public required string Name { get; set; } 

		[MaxLength(DescriptionMaxLenght)]
		[MinLength(DescriptionMinLenght)]
		[Required]
        public required string Description { get; set; }

		[Required]
		[MinLength(DescriptionMinLenght)]
		[MaxLength(DescriptionMaxLenght)]
		public required string AtmosphereDescription { get; set; }

		[Required]
		[MinLength(DescriptionMinLenght)]
		[MaxLength(DescriptionMaxLenght)]
		public required string MenuDescription { get; set; }

		[Required]
		[MinLength(AddressMinLenght)]
		[MaxLength(AddressMaxLenght)]
        public required string Address { get; set; }

		
		public string? ChefsDishImagePath { get; set; } 

		[Required]
		[MinLength(NameMinLenght)]
		[MaxLength(NameMaxLenght)]
		public required string ChefsDishName { get; set; }

		
		public string? ImagePath { get; set; } 

		[Required]
		public Guid CategoryId { get; set; }

		public List<Category> Categories { get; set; } = new List<Category>();

		[Required]
		[MaxLength(CityNameMaxLenght)]
		[MinLength(CityNameMinLenght)]
		public required string City { get; set; } 

		[Required]
		[MaxLength(CuisineNameMaxLenght)]
		[MinLength(CuisineNameMinLenght)]
		public required string CuisineName { get; set; }

		[Required]
		public int PriceRange { get; set; } 
    }
}

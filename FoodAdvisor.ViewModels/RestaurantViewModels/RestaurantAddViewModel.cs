using FoodAdvisor.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.Restaurant;
using static FoodAdvisor.Common.EntityValidationConstants.City;


namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
	public class RestaurantAddViewModel
	{
		[MaxLength(NameMaxLenght)]
		[MinLength(NameMinLenght)]
		[Required]
		public string Name { get; set; } = null!;

		[MaxLength(DescriptionMaxLenght)]
		[MinLength(DescriptionMinLenght)]
		[Required]
        public  string Description { get; set; } = null!;

		[Required]
		[MinLength(AddressMinLenght)]
		[MaxLength(AddressMaxLenght)]
        public  string Address { get; set; } = null!;


		public string? ImagePath { get; set; }

		[Required]
		public Guid CategoryId { get; set; }

		public List<Category> Categories { get; set; } = new List<Category>();

		[Required]
		[MaxLength(CityNameMaxLenght)]
		[MinLength(CityNameMinLenght)]
		public string City { get; set; } = null!;


    }
}

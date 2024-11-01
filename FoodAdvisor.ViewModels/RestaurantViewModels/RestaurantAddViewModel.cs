using FoodAdvisor.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.Restaurant;

namespace FoodAdvisor.ViewModels.RestaurantViewModels
{
	public class RestaurantAddViewModel
	{
		[MaxLength(NameMaxLenght)]
		[MinLength(NameMinLenght)]
		[Required]
        public  string Name { get; set; } = string.Empty;

		[MaxLength(DescriptionMaxLenght)]
		[MinLength(DescriptionMinLenght)]
		[Required]
        public  string Description { get; set; } = string.Empty;

        [Required]
		[MinLength(AddressMinLenght)]
		[MaxLength(AddressMaxLenght)]
        public  string Address { get; set; } = string.Empty;


        public string? ImageURL { get; set; }

		[Required]
		public Guid CategoryId { get; set; }

		public List<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public Guid CityId { get; set; }

        public List<City> Cities { get; set; } = new List<City>();

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.Cuisine;

namespace FoodAdvisor.Data.Models
{
	public class RestaurantCuisine
	{
		[Key]
        public Guid Id { get; set; }  = Guid.NewGuid();

		[Required]
		[MaxLength(CuisineNameMaxLenght)]
		[Comment("The name of the Cuisine type.")]
		public string Name { get; set; } = null!;

		[Comment("A collection of the Restaurants with the same Cuisine type.")]
		public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
	}
}

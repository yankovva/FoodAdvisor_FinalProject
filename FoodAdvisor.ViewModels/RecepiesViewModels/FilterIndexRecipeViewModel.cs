using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
	public class FilterIndexRecipeViewModel
	{
		public IEnumerable<RecepieIndexViewModel>? Recipes { get; set; }

		public string? SearchQuery { get; set; }

		public string? CategoryFilter { get; set; }

		public IEnumerable<string>? AllCategories { get; set; }

		public string? DificultyFilter { get; set; }

		public IEnumerable<string>? AllDificulties { get; set; }

		public int? CurrentPage { get; set; } = 1;

		public int? EntitiesPerPage { get; set; } = 16;

		public int? TotalPages { get; set; }
	}
}

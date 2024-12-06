using FoodAdvisor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FoodAdvisor.Common.EntityValidationConstants.Recepie;
namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
	public class AddRecepieViewModel
	{
        [Required]
        [MinLength(NameMinLenght)]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

		public string? ImagePath { get; set; } 
		
		[Required]
		public int CookingTime { get; set; }

        [Required]
        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

		[Required]
		[MaxLength(CookingStepsMaxLenght)]
		[MinLength(CookingStepsMinLenght)]
		public string CookingSteps { get; set; } = null!;

		[Required]
		[MinLength(ProductsMinLengt)]
		[MaxLength(ProductsMaxLenght)]
		[RegularExpression(@"^([a-zA-Z\s]+(?:\s*-\s*\d+(\s*(kg|gr|g|l|ml|oz))?)?)(,\s*[a-zA-Z\s]+(?:\s*-\s*\d+(\s*(kg|gr|g|l|ml|oz))?)?)*$",
					   ErrorMessage = "Invalid format. Ingredients should be separated with a comma and may optionally include quantities (e.g. banana, flour- 500gr).")]
		public string Products { get; set; } = null!;
		[Required]
		public int Servings { get; set; } 

		[Required]
		public Guid CategoryId { get; set; }

		[Required]
		public int DificultyId { get; set; }
		public List<RecepieCategory> Categories { get; set; } = new List<RecepieCategory>();
		public List<RecepieDificulty> Dificulty { get; set; } = new List<RecepieDificulty>();

	}
}

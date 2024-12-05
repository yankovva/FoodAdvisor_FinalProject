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
        public required string Name { get; set; } 

		public string? ImagePath { get; set; } 
		
		[Required]
		public int CookingTime { get; set; }

        [Required]
        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public required string Description { get; set; }

		[Required]
		[MaxLength(CookingStepsMaxLenght)]
		[MinLength(CookingStepsMinLenght)]
		public required string CookingSteps { get; set; }

		[Required]
		[MinLength(ProductsMinLengt)]
		[MaxLength(ProductsMaxLenght)]
		[RegularExpression(@"^([a-zA-Z\s]+(?:\s*-\s*\d+(\s*(kg|gr|g|l|ml|oz))?)?)(,\s*[a-zA-Z\s]+(?:\s*-\s*\d+(\s*(kg|gr|g|l|ml|oz))?)?)*$",
					   ErrorMessage = "Invalid format. Ingredients should be separated with a comma and may optionally include quantities (e.g. banana, flour- 500gr).")]
		public required string Products { get; set; }
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

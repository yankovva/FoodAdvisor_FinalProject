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

        [MinLength(URLMinLenght)]
        [MaxLength(URLMaxLEnght)]
        public string? ImageURL { get; set; }
        [Required]
        public int CookingTime { get; set; }
        [Required]
        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;
    }
}

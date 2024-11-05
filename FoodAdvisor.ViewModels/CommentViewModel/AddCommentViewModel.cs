using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FoodAdvisor.Common.EntityValidationConstants.RestaurantComment;

namespace FoodAdvisor.ViewModels.CommentViewModel
{
	public class AddCommentViewModel
	{
		[Required]
		[MaxLength(MessageMaxLenght)]
		[MinLength(MessageMinLenght)]
		public string Message { get; set; } = null!;
		
		
	}
}

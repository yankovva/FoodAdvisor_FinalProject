using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodAdvisor.Common.EntityValidationConstants.RestaurantComment;
namespace FoodAdvisor.Data.Models
{
	public class RestaurantComment
	{
		[Key]
		[Comment("Identifier of the Comment.")]
        public int Id { get; set; }

		[Required]
		[MaxLength(MessageMaxLenght)]
		[Comment("The message of the Comment.")]
		public string Message { get; set; } = null!;

		public bool IsDeleted { get; set; }

		public Guid UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; } = null!;

		public Guid RestaurantId { get; set; }
		[ForeignKey(nameof(RestaurantId))]
		public Restaurant Restaurant { get; set; } = null!;

		[Required]
		[Comment("Date of creation of the Comment.")]
		public DateTime CreatedDate { get; set; }

	}
}

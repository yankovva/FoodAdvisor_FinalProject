using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodAdvisor.Common.EntityValidationConstants.Comment;

namespace FoodAdvisor.Data.Models
{
    public class RecepieComment
    {
        [Key]
        [Comment("Identifier of the Recepie.")]
        public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
        [MaxLength(MessageMaxLenght)]
        [Comment("The message of the Recepie.")]
        public string Message { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public Guid RecepieId { get; set; }
        [ForeignKey(nameof(RecepieId))]
        public Recepie Recepie { get; set; } = null!;

        [Required]
        [Comment("Date of creation of the Comment.")]
        public DateTime CreatedDate { get; set; }
    }
}

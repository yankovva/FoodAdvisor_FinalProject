using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.Comment;
namespace FoodAdvisor.Data.Models
{
    public class Comment
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

        public Guid? RecepieId { get; set; }
        [ForeignKey(nameof(RecepieId))]
        public Recepie? Recepie { get; set; }

        public Guid? RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public  Restaurant? Restaurant { get; set; } 

        [Required]
        [Comment("Date of creation of the Comment.")]
        public DateTime CreatedDate { get; set; }
    }
}

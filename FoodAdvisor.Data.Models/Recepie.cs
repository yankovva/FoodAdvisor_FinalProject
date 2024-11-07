using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodAdvisor.Common.EntityValidationConstants.Recepie;
namespace FoodAdvisor.Data.Models
{
	public class Recepie
	{
		[Key]
        public Guid Id { get; set; }

		[Required]
		[MaxLength(NameMaxLenght)]
		[Comment("Name of the Recepie.")]
		public string Name { get; set; } = null!;

		[Required]
		[Comment("Cooking time of the Recepie.")]

		public int CookingTime { get; set; }
		[Required]
		[Comment("Date of creation of the Recepie.")]
		public DateTime CreatedOn { get; set; }

		[Required]
		[MaxLength(DescriptionMaxLenght)]
		[Comment("Description of the Recepie.")]
		public string Description { get; set; } = null!;

		[MaxLength(URLMaxLEnght)]
        public string? ImageURL { get; set; }

        public Guid PublisherId { get; set; }
		[ForeignKey(nameof(PublisherId))]
		public ApplicationUser Publisher { get; set; } = null!;

		public virtual ICollection<UserRecepie> UsersRecepies{ get; set; } = new List<UserRecepie>();
        public bool IsDeleted { get; set; }
    }
}

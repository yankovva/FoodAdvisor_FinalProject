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

        [Required]
		[Comment("Number of servings for the Recepie")]
        public int NumberOfServing { get; set; }

		public int RecepieDificultyId { get; set; }
		[ForeignKey(nameof(RecepieDificultyId))]
		public RecepieDificulty RecepieDificulty { get; set; } = null!;

		[Required]
		[MaxLength(ProductsMaxLenght)]
		[Comment("Needed products for the Recepie.")]
		public string Products { get; set; } = null!;

		[MaxLength(URLMaxLEnght)]
        public string? ImageURL { get; set; }

        public Guid PublisherId { get; set; }
		[ForeignKey(nameof(PublisherId))]
		public ApplicationUser Publisher { get; set; } = null!;

		public Guid RecepieCategoryId { get; set; }
		[ForeignKey(nameof(RecepieCategoryId))]
		public RecepieCategory RecepieCategory { get; set; } = null!;

		public virtual ICollection<UserRecepie> UsersRecepies{ get; set; } = new List<UserRecepie>();
        public ICollection<RecepieComment> RecepieComments { get; set; } = new List<RecepieComment>();

        public bool IsDeleted { get; set; }
    }
}

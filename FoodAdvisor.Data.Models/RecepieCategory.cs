using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FoodAdvisor.Data.Models
{
	public class RecepieCategory
	{
		[Key]
		[Comment("The idemtifier of the Recepie category.")]
		public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
		[Comment("The name of the Recepie category.")]
		public string Name { get; set; } = null!;

		public ICollection<Recepie> Recepies { get; set; } = new List<Recepie>();

    }
}
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FoodAdvisor.Data.Models
{
	public class RecepieDificulty
	{
		[Key]
		[Comment("The idemtifier of the Recepie Dificulty.")]
		public int Id { get; set; } 
		[Required]
		[Comment("The name of the Recepie dificulty level.")]
		public string DificultyName { get; set; } = null!;

		[Comment("A Collection of recepies with the same dificulty level.")]
        public ICollection<Recepie> Recepies { get; set; } =  new List<Recepie>();
		
    }
}
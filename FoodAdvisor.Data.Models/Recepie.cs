using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Models
{
	public class Recepie
	{
		[Key]
        public Guid Id { get; set; }

		[Required]

		public string Name { get; set; } = null!;
		[Required]
        public int CookingTime { get; set; }
		[Required]
		public DateTime CreatedOn { get; set; }
		[Required]
		public string RecepieSteps { get; set; } = null!;
        public Guid PublisherId { get; set; }
		[ForeignKey(nameof(PublisherId))]
		public ApplicationUser Publisher { get; set; } = null!;

		public virtual ICollection<UserRecepie> UsersRecepies{ get; set; } = new List<UserRecepie>();
        public bool IsDeleted { get; set; }
    }
}

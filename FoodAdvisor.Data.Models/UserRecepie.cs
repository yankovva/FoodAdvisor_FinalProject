using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.EntityValidationConstants;

namespace FoodAdvisor.Data.Models
{
	[PrimaryKey(nameof(ApplicationUserId), nameof(RecepieId))]

	public class UserRecepie
	{
		[Comment("Identifier of the ApplicationUser")]
		public Guid ApplicationUserId { get; set; }
		public virtual ApplicationUser User { get; set; } = null!;

		[Comment("Identifier of the Restaurant")]
		public Guid RecepieId { get; set; }
		public virtual Recepie Recepie { get; set; } = null!;
	}
}
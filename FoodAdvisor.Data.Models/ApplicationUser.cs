using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();
		}
        [Comment("First name of the User.")]
        public string? FirstName { get; set; }
		[Comment("Last name of the User.")]
		public string? LastName { get; set; }
		[Comment("Path for the Profile picture of the User.")]
		public string? ProfilePricturePath { get; set; }
		[Comment("Short descripton of the User.")]
        public string? AboutMe { get; set; }
		[Comment("Birthday of the User.")]
        public DateTime? Birthday { get; set; }
		[Comment("Date of creation of the User.")]
        public DateTime Createdon { get; set; }

        public virtual ICollection<UserRestaurant> Restaurants { get; set; } = new HashSet<UserRestaurant>();
		public virtual ICollection<UserRecepie> Recepies { get; set; } = new HashSet<UserRecepie>();
		public virtual ICollection<RestaurantComment> RestaurantsComments { get; set; } = new List<RestaurantComment>();
        public virtual ICollection<RecepieComment> RecepiesComments { get; set; } = new List<RecepieComment>();


    }
}
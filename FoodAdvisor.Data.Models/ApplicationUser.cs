using Microsoft.AspNetCore.Identity;
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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePricture { get; set; }
        public string? AboutMe { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime Createdon { get; set; }
        public virtual ICollection<UserRestaurant> Restaurants { get; set; } = new HashSet<UserRestaurant>();
		public virtual ICollection<UserRecepie> Recepies { get; set; } = new HashSet<UserRecepie>();
		public virtual ICollection<RestaurantComment> RestaurantsComments { get; set; } = new List<RestaurantComment>();
        public virtual ICollection<RecepieComment> RecepiesComments { get; set; } = new List<RecepieComment>();


    }
}
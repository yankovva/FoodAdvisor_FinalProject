using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.User;

namespace FoodAdvisor.Data.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();
		}
        [Comment("First name of the User.")]
		[MaxLength(FirstNameMaxLenght)]
        public string? FirstName { get; set; }
		[Comment("Last name of the User.")]
		[MaxLength(LastNameMaxLenght)]
		public string? LastName { get; set; }
		[Comment("Path for the Profile picture of the User.")]
		public string ProfilePricturePath { get; set; }

		[Comment("Short descripton of the User.")]
		[MaxLength(AboutMeMaxLenght)]
        public string? AboutMe { get; set; }

		[Comment("User Country")]
		[MaxLength(CountryMaxLenght)]
        public string? Country { get; set; }

		[Comment("Date of creation of the User.")]
        public DateTime Createdon { get; set; }

		//FavouriteRestaurants
        public virtual ICollection<UserRestaurant> Restaurants { get; set; } = new HashSet<UserRestaurant>();

		//Favourite Recepies
		public virtual ICollection<UserRecepie> Recepies { get; set; } = new HashSet<UserRecepie>();

		public virtual ICollection<Recepie> AddedRecepies { get; set; } = new List<Recepie>();

		public virtual ICollection<Comment> UsersComments { get; set; } = new List<Comment>();


    }
}
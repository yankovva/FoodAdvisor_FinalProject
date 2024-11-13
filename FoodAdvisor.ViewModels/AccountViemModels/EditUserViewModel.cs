using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.User;

namespace FoodAdvisor.ViewModels.AccountViemModels
{
	public class EditUserViewModel
	{
		[MaxLength(FirstNameMaxLenght)]
		[MinLength(FirstNameMinLenght)]
		public string? FirstName { get; set; }

		[MaxLength(LastNameMaxLenght)]
		[MinLength(LastNameMinLenght)]
		public string? LastName { get; set; }
		public DateTime? BirthDay { get; set; }

		[MaxLength(AboutMeMaxLenght)]
		[MinLength(AboutMeMinLenght)]
		public string? AboutMe { get; set; }

		[MaxLength(UsernameMaxLenght)]
		public string UserName { get; set; } = null!;

        public string? ProfilePicture { get; set; }
    }
}

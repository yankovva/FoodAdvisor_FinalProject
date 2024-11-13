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
		[MinLength(FirstNameMaxLenght)]
		public string? FirstName { get; set; }

		[MaxLength(LastNameMaxLenght)]
		[MinLength(LastNameMaxLenght)]
		public string? LastName { get; set; }
		public DateTime? BirthDay { get; set; }

		[MaxLength(AboutMeMaxLenght)]
		[MinLength(AboutMeMinLenght)]
		public string? AboutMe { get; set; }
		public string? ProfilePricturePath { get; set; }

		[MaxLength(UsernameMaxLenght)]
		public string UserName { get; set; } = null!;
    }
}

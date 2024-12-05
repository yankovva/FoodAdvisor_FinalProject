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

		[MaxLength(CountryMaxLenght)]
		[MinLength(CountryMinLenght)]
		public string? Country { get; set; }

		[MaxLength(AboutMeMaxLenght)]
		[MinLength(AboutMeMinLenght)]
		public string? AboutMe { get; set; }

		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
		public string? UserName { get; set; } 

		[EmailAddress]
		public string? Email { get; set; }

		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string? ConfirmPassword { get; set; }

		public string? ProfilePicture { get; set; }
    }
}

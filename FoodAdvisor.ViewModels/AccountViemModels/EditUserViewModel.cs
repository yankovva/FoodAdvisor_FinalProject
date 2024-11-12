using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.AccountViemModels
{
	public class EditUserViewModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime? BirthDay { get; set; }
		public string? AboutMe { get; set; }
		public string? ProfilePricture { get; set; }
		public string UserName { get; set; } = null!;
    }
}

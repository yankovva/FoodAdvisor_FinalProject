using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.UserViewModels
{
    public class ManagerFormViewModel
    {
		public string UserId { get; set; } = null!;

		[Required]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		public string Address { get; set; } = null!;
	}
}

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
		public required string UserId { get; set; } 

		[Required]
		public required string PhoneNumber { get; set; } 

		[Required]
		public required string Address { get; set; }
	}
}

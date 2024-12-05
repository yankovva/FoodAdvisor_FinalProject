using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.AccountViemModels
{
	public class IndexGetUserInfoViewModel
	{
		public required string Id { get; set; } 
        public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? UserName { get; set; }
		public string? Country { get; set; }
		public DateTime CreatedOn { get; set; }
		public string? AboutMe { get; set; }
        public string? ProfilePricture { get; set; }
		public required string Email { get; set; }
		public virtual IEnumerable<UserAddedRecepiesViewModel> UserAddedRecepies { get; set; } = new List<UserAddedRecepiesViewModel>();
      
	}
}

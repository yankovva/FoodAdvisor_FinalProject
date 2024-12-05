using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
	public class DeleteRecepieViewModel
	{
        public required string Id { get; set; } 
        public required string Name { get; set; } 
		public DateTime CreatedOn { get; set; }
        public required string Publisher { get; set; } 
        public required string ImagePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
	public class DeleteRecepieViewModel
	{
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!; 
		public DateTime CreatedOn { get; set; }
        public string Publisher { get; set; } = null!; 
        public string ImagePath { get; set; } = null!;
    }
}

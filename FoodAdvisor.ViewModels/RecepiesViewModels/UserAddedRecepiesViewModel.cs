using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
	public class UserAddedRecepiesViewModel
	{
        public required string Name { get; set; }
		public required string DificultyLevel { get; set; }
		public required string Categodry { get; set; }
		public required string AddedOn { get; set; }
		public required string Image { get; set; }
		public required int Likes { get; set; }
		public required int Comments { get; set; }
	}
}

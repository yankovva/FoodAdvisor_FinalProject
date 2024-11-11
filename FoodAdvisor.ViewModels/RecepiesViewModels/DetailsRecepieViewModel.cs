using FoodAdvisor.ViewModels.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
	public class DetailsRecepieViewModel
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
		public DateTime CreatetOn { get; set; }
        public string Publisher { get; set; } = null!;
		public string ImageURL { get; set; } = null!;
		public int CookingTime { get; set; }
		public IEnumerable<CommentAllViewModel> AllComment { get; set; } = new List<CommentAllViewModel>();

	}
}

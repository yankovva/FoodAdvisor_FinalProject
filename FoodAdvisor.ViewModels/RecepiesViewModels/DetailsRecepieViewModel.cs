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
		public string Products { get; set; } = null!;
		public DateTime CreatetOn { get; set; }
        public string Publisher { get; set; } = null!;
		public string PublisherQuote { get; set; } = null!;
		public string PublisherId { get; set; } = null!;
		public string PublisherFullName { get; set; } = null!;
        public string PublisherPicture { get; set; } = null!;
		public string PublisherLocation { get; set; } = null!;
		public string ImagePath { get; set; } = null!;
		public int CookingTime { get; set; }
		public string Category { get; set; } = null!;
        public int  Servings { get; set; }
		public string Dificulty { get; set; } = null!;
        public IEnumerable<CommentAllViewModel> AllComment { get; set; } = new List<CommentAllViewModel>();

	}
}

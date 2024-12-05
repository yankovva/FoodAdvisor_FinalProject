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
        public required string Name { get; set; } 
        public required string Description { get; set; } 
		public required string CookingSteps { get; set; }
		public List<string> Products { get; set; } = new List<string>();
		public DateTime CreatetOn { get; set; }
        public required string Publisher { get; set; }
		public required string PublisherQuote { get; set; } 
		public required string PublisherId { get; set; } 
		public required string PublisherFullName { get; set; } 
        public  required string PublisherPicture { get; set; } 
		public required string PublisherLocation { get; set; }
		public required string ImagePath { get; set; } 
		public int CookingTime { get; set; }
		public required string Category { get; set; } 
        public int  Servings { get; set; }
		public required string Dificulty { get; set; }
        public IEnumerable<CommentAllViewModel> AllComment { get; set; } = new List<CommentAllViewModel>();

	}
}

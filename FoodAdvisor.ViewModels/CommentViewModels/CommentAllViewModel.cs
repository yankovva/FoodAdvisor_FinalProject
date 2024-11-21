using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.CommentViewModel
{
	public class CommentAllViewModel
	{
		public required string Id { get; init; }
		public required string Message { get; set; }
		public DateTime CreatedOn { get; set; }
		public required string UserId { get; set; }
		public required string UserName { get; set; }
		public required string ProfilePicture { get; set; }


	}
}

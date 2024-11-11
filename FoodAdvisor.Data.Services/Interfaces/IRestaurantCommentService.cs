using FoodAdvisor.ViewModels.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRestaurantCommentService
	{
		Task<bool> AddAsync(string recepieId, Guid userId, AddCommentViewModel model);
		Task<bool> DeleteAsync(string recepieId);
	}
}

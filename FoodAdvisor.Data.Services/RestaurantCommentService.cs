using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
	public class RestaurantCommentService : BaseService, IRestaurantCommentService
	{
		private readonly IRepository<RestaurantComment, Guid> restaurantRepository;
        public RestaurantCommentService(IRepository<RestaurantComment, Guid> restaurantRepository)
        {
				this.restaurantRepository = restaurantRepository;
        }
        public async Task<bool> AddAsync(string restaurantId, Guid userId, AddCommentViewModel model)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(restaurantId, ref restaurantGuid);
			if (!isGuidValid)
			{
				return false;
			}

			RestaurantComment comment = new()
			{
				RestaurantId = Guid.Parse(restaurantId),
				Message = model.Message,
				CreatedDate = DateTime.Now,
				UserId = userId
			};

			await this.restaurantRepository.AddAsync(comment);
			return true;
		}

		public async Task<bool> DeleteAsync(string restaurantId)
		{
			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(restaurantId, ref restaurantGuid);
			if (!isGuidValid)
			{
				return false;
			}

			RestaurantComment? comment = await this.restaurantRepository
				.GetByIdAsync(restaurantGuid);

			if (comment == null || comment.IsDeleted == true)
			{
				return false;
			}
			comment.IsDeleted = true;
			await this.restaurantRepository.SaveChangesAsync();

			return true;
		}
	}
}

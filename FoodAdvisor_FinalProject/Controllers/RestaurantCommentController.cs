using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor_FinalProject.Controllers
{
	public class RestaurantCommentController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;

		public RestaurantCommentController(FoodAdvisorDbContext _dbContext)
		{
			this.dbContext = _dbContext;

		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			Guid commentGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref commentGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}
			RestaurantComment? comment = await this.dbContext
				.RestaurantsComments
				.Where(c => c.IsDeleted == false)
				.FirstOrDefaultAsync(c => c.Id == commentGuid);
			
			if (comment == null)
			{
				throw new ArgumentException("Invalid Id");
			}

			comment.IsDeleted = true;
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction("Index", "Restaurant");
		}

		[HttpPost]
		public async Task<IActionResult> Add(string restaurantid, [Bind("Message")] AddCommentViewModel model )
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);

			RestaurantComment comment = new()
			{
				RestaurantId = Guid.Parse(restaurantid),
				Message = model.Message,
				CreatedDate = DateTime.Now,
				UserId = userguid
			};

			 await this.dbContext.RestaurantsComments.AddAsync(comment);
			 await this.dbContext.SaveChangesAsync();

			return RedirectToAction("Index", "Restaurant");
		}

	}
}

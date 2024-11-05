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
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddCommentViewModel model, string id)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			Guid restaurantGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref restaurantGuid);
			if (!isGuidValid)
			{
				return this.RedirectToAction(nameof(Index));
			}

			RestaurantComment comment = new RestaurantComment()
			{
				Message = model.Message,
				UserId = Guid.Parse(GetCurrentUserId()),
				RestaurantId = restaurantGuid,
				CreatedDate = DateTime.Now
			};

			await this.dbContext.RestaurantsComments.AddAsync(comment);
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction("Details", "Restaurant");
		}

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

	}
}

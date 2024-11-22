using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.EntityValidationConstants;

namespace FoodAdvisor_FinalProject.Controllers
{
	public class RestaurantCommentController : BaseController
	{
		private readonly IRestaurantCommentService commentService;


		public RestaurantCommentController(IRestaurantCommentService commentService)
		{
			this.commentService = commentService;

		}

		[HttpPost]
		public async Task<IActionResult> Delete(string commentId , string restaurantId)
		{
            bool isDeleted = await this.commentService
                .DeleteAsync(commentId);
            if (isDeleted == false)
            {
                //TODO: Add a message
                return RedirectToAction("Index", "Restaurant", new { id = restaurantId });
			}

            return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
		}

		[HttpPost]
		public async Task<IActionResult> Add(string restaurantid, [Bind("Message")] AddCommentViewModel model )
		{
            Guid userguid = Guid.Parse(GetCurrentUserId()!);
			bool isAdded = await this.commentService
				.AddAsync(restaurantid, userguid, model);

            if (isAdded == false)
            {
                //TODO: Add a message
                return RedirectToAction("Index", "Restaurant", new { id = restaurantid });
            }

            return RedirectToAction("Details", "Restaurant", new { id = restaurantid } );
		}

	}
}

using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		public async Task<IActionResult> Delete(string id)
		{
            bool isDeleted = await this.commentService
                .DeleteAsync(id);
            if (isDeleted == false)
            {
                //TODO: Add a message
                return RedirectToAction("Index", "Restaurant");
            }

            return RedirectToAction("Index", "Restaurant");
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

            return RedirectToAction("Index", "Restaurant", new { id = restaurantid } );
		}

	}
}

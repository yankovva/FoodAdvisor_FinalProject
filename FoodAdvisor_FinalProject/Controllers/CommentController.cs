using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdvisor_FinalProject.Controllers
{
    [Authorize]
    public class CommentController : BaseController
    {
        private readonly ICommentService commentServie;

        public CommentController(ICommentService commentServie)
        {
            this.commentServie = commentServie;
        }

        [HttpPost]
        public async Task<IActionResult> Add(string? recepieId, string? restaurantId, [Bind("Message")] AddCommentViewModel model)
        {
            Guid userguid = Guid.Parse(GetCurrentUserId()!);

            bool isAdded = await this.commentServie
                .AddAsync(recepieId,restaurantId, userguid, model);

            if (isAdded == false)
            {
                //TODO: Add a message
                if (recepieId != null)
                {
                    return RedirectToAction("Details", "Recepie", new { id = recepieId });
                }
                else if (restaurantId != null)
                {
                    return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
                }
            }

            if (recepieId != null)
            {
                return RedirectToAction("Details", "Recepie", new { id = recepieId });
            }
            
              return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string commentId, string? recepieId, string? restaurantId)
        {

            bool isDeleted = await this.commentServie
                .DeleteAsync(commentId);

            if (isDeleted == false)
            {
                //TODO: Add a message
                if (recepieId != null)
                {
                    return RedirectToAction("Details", "Recipes", new { id = recepieId });
                }
                else if (restaurantId != null)
                {
                    return RedirectToAction("Details", "Restaurants", new { id = restaurantId });
                }
            }

            if (recepieId != null)
            {
                return RedirectToAction("Details", "Recipes", new { id = recepieId });
            }

            return RedirectToAction("Details", "Restaurants", new { id = restaurantId });
        }
    }
}

using FoodAdvisor.Common;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Common.EntityValidationConstants;
using static FoodAdvisor.Common.ErrorMessages;

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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(string? recepieId, string? restaurantId, [Bind("Message")] AddCommentViewModel model)
        {
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}
			try
            {
				bool isAdded = await this.commentServie
				.AddAsync(recepieId, restaurantId, userId, model);

				if (isAdded == false)
				{
					if (recepieId != null)
					{
						TempData[ErrorMessage] = EntityNotFoundMessage;
						return RedirectToAction("Details", "Recepie", new { id = recepieId });
					}
					else if (restaurantId != null)
					{
						TempData[ErrorMessage] = EntityNotFoundMessage;
						return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
					}
				}
				if (recepieId != null)
				{
					TempData[SuccessMessage] = CommentAddingSuccesfullMessage;
					return RedirectToAction("Details", "Recepie", new { id = recepieId });
				}
				TempData[SuccessMessage] = CommentAddingSuccesfullMessage;
				return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
			}
            catch (ArgumentException ex)
            {
				TempData[WarningMessage] = ex.Message;
			}

			if (recepieId != null)
			{
				return RedirectToAction("Details", "Recepie", new { id = recepieId });
			}
			return RedirectToAction("Details", "Restaurant", new { id = restaurantId });


		}

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(string commentId, string? recepieId, string? restaurantId)
        {

            bool isDeleted = await this.commentServie
                .DeleteAsync(commentId);

            if (isDeleted == false)
            {
                
                if (recepieId != null)
				{
					TempData[ErrorMessage] = InvalidGuidMessage;
					return RedirectToAction("Details", "Recepie", new { id = recepieId });
                }
                else if (restaurantId != null)
                {
					TempData[ErrorMessage] = InvalidGuidMessage;
					return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
                }
            }

            if (recepieId != null)
            {
				TempData[SuccessMessage] = DeletingWasSuccesfullMessage;
				return RedirectToAction("Details", "Recepie", new { id = recepieId });
            }

			TempData[SuccessMessage] = DeletingWasSuccesfullMessage;
			return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }
    }
}

using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.EntityValidationConstants;

namespace FoodAdvisor_FinalProject.Controllers
{
    public class RecepieCommentController : BaseController
    {
		private readonly IRecepieCommentService commentServie;

        public RecepieCommentController(IRecepieCommentService commentServie)
        {
			this.commentServie = commentServie;
        }

		[HttpPost]
		public async Task<IActionResult> Add(string recepieId, [Bind("Message")] AddCommentViewModel model)
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);

			bool isAdded = await this.commentServie
				.AddAsync(recepieId, userguid, model);
			if (isAdded == false)
			{
				//TODO: Add a message
                return RedirectToAction("Details", "Recepie", new { id = recepieId });
            }

			return RedirectToAction("Details", "Recepie", new { id = recepieId });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string commentId, string recepieId)
		{
			bool isDeleted = await this.commentServie
				.DeleteAsync(commentId);
            if (isDeleted == false)
            {
                //TODO: Add a message
                return RedirectToAction("Index", "Recepie", new { id = recepieId });
            }
            return RedirectToAction("Details", "Recepie", new { id = recepieId });
		}
	}
}

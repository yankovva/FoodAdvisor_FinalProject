using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return RedirectToAction("Index", "Recepie");
            }

			return RedirectToAction("Index", "Recepie");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			bool isDeleted = await this.commentServie
				.DeleteAsync(id);
            if (isDeleted == false)
            {
                //TODO: Add a message
                return RedirectToAction("Index", "Recepie");
            }
            return RedirectToAction("Index", "Recepie");
		}
	}
}

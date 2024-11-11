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
        private readonly FoodAdvisorDbContext dbContext;
		private readonly IRecepieCommentService commentServie;

        public RecepieCommentController(FoodAdvisorDbContext _dbContext, IRecepieCommentService commentServie)
        {
            this.dbContext = _dbContext;
			this.commentServie = commentServie;
        }

		[HttpPost]
		public async Task<IActionResult> Add(string recepieId, [Bind("Message")] AddCommentViewModel model)
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);

			await this.commentServie.AddAsync(recepieId, userguid, model);

			return RedirectToAction("Index", "Recepie");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			bool isDeleted = await this.commentServie
				.DeleteAsync(id);

			return RedirectToAction("Index", "Recepie");
		}


	}
}

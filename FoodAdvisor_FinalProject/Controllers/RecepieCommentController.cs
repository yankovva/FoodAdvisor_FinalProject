using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor_FinalProject.Controllers
{
    public class RecepieCommentController : BaseController
    {
        private readonly FoodAdvisorDbContext dbContext;

        public RecepieCommentController(FoodAdvisorDbContext _dbContext)
        {
            this.dbContext = _dbContext;

        }

		[HttpPost]
		public async Task<IActionResult> Add(string recepieId, [Bind("Message")] AddCommentViewModel model)
		{
			Guid userguid = Guid.Parse(GetCurrentUserId()!);

			RecepieComment comment = new()
			{
				RecepieId = Guid.Parse(recepieId),
				Message = model.Message,
				CreatedDate = DateTime.Now,
				UserId = userguid
			};

			await this.dbContext.RecepiesComments.AddAsync(comment);
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction("Index", "Recepie");
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
			RecepieComment? comment = await this.dbContext
				.RecepiesComments
				.Where(c => c.IsDeleted == false)
				.FirstOrDefaultAsync(c => c.Id == commentGuid);

			if (comment == null)
			{
				throw new ArgumentException("Invalid Id");
			}

			comment.IsDeleted = true;
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction("Index", "Recepie");
		}


	}
}

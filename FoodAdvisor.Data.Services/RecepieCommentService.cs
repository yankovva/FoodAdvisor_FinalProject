using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
    public class RecepieCommentService : BaseService, IRecepieCommentService
    {
		private readonly IRepository<RecepieComment, Guid> commentRepository;

		public RecepieCommentService(IRepository<RecepieComment, Guid> commentRepository)
		{
			this.commentRepository = commentRepository;
		}

		public async Task<bool> AddAsync(string recepieId, Guid userId, AddCommentViewModel model)
		{
            Guid recepieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
            if (!isGuidValid)
            {
                return false;
            }

            RecepieComment comment = new()
			{
				RecepieId = recepieGuid,
				Message = model.Message,
				CreatedDate = DateTime.Now,
				UserId = userId
			};

			await this.commentRepository.AddAsync(comment);
			return true;
		}

		public async Task<bool> DeleteAsync(string recepieId)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
			if (!isGuidValid)
			{
				return false;
			}

			RecepieComment? comment = await  this.commentRepository
                .GetByIdAsync(recepieGuid);
			
			if (comment == null || comment.IsDeleted == true)
			{
				return false;
			}
			comment.IsDeleted = true;
			await this.commentRepository.SaveChangesAsync();

			return true;
		}
	}
}

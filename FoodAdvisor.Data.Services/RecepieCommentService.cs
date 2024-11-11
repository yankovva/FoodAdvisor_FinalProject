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
		private readonly IRepository<RecepieComment, Guid> recepieCommentRepository;

		public RecepieCommentService(IRepository<RecepieComment, Guid> recepieCommentRepository)
		{
			this.recepieCommentRepository = recepieCommentRepository;
		}

		public async Task AddAsync(string recepieId, Guid userId, AddCommentViewModel model)
		{

			RecepieComment comment = new()
			{
				RecepieId = Guid.Parse(recepieId),
				Message = model.Message,
				CreatedDate = DateTime.Now,
				UserId = userId
			};

			await this.recepieCommentRepository.AddAsync(comment);
		}

		public async Task<bool> DeleteAsync(string recepieId)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
			if (!isGuidValid)
			{
				return false;
			}

			RecepieComment? comment = await  this.recepieCommentRepository
				.GetByIdAsync(recepieGuid);
			
			if (comment == null || comment.IsDeleted == true)
			{
				return false;
			}
			comment.IsDeleted = true;
			await this.recepieCommentRepository.SaveChangesAsync();

			return true;
		}
	}
}

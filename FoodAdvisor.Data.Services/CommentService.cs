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
    public class CommentService : BaseService, ICommentService
    {
        private readonly IRepository<Comment, Guid> commentRepository;

        public CommentService(IRepository<Comment, Guid> commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public async Task<bool> AddAsync(string? recepieId, string? restaurantId, Guid userId, AddCommentViewModel model)
        {

            if (model.Message == null)
            {
                return false;
            }
            Comment comment = new()
            {
                Message = model.Message,
                CreatedDate = DateTime.Now,
                UserId = userId
            };

            Guid recepieGuid = Guid.Empty;
            Guid restaurantGuid = Guid.Empty;
            if (recepieId != null)
            {
                bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
                if (isGuidValid)
                {
                    recepieGuid = Guid.Parse(recepieId);
                }
                 comment.RecepieId = recepieGuid;
            }
            else if (restaurantId != null)
            {
                bool isGuidValid = this.IsGuidValid(restaurantId, ref restaurantGuid);
                if (isGuidValid)
                {
                    restaurantGuid = Guid.Parse(restaurantId);
                }
                comment.RestaurantId = restaurantGuid;
                    
            }
            else if (restaurantId == null && recepieId == null)
            {
                return false;
            }
            
            await this.commentRepository.AddAsync(comment);

            return true;
        }

        public async Task<bool> DeleteAsync(string commentId)
        {
            Guid CommentGuid = Guid.Parse(commentId);

            Comment? comment = await this.commentRepository
                .GetByIdAsync(CommentGuid);

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

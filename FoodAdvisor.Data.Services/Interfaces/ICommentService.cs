using FoodAdvisor.ViewModels.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
    public interface ICommentService
    {
        Task<bool> AddAsync(string? recepieId,string? restaurantId, Guid userId, AddCommentViewModel model);
        Task<bool> DeleteAsync(string? commentId);
    }
}

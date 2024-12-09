using FoodAdvisor.ViewModels.AccountViemModels;
using Microsoft.AspNetCore.Http;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IAccountService
    {
        public Task<IndexGetUserInfoViewModel> IndexGetUserAsync(Guid userId);

        public Task<EditUserViewModel> GetEditUserViewAsync(Guid userId);
		public Task<bool>EditUserAsync(EditUserViewModel model, string userId);

        public Task<bool> UpdateProfilePictureAsync(IFormFile file, Guid userId);
	}
}

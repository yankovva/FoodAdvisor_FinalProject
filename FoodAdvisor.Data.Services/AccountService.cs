using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.AccountViemModels;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ApplicationConstants;
using static FoodAdvisor.Common.EntityValidationConstants;
using static FoodAdvisor.Common.ErrorMessages;

namespace FoodAdvisor.Data.Services
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly IRepository<ApplicationUser, Guid> accountRepository;
		private readonly IWebHostEnvironment enviorment;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IFileService fileService;
		public AccountService(IRepository<ApplicationUser, Guid> accountRepository, IWebHostEnvironment enviorment,
			UserManager<ApplicationUser> userManager, IFileService fileService)
		{
			this.accountRepository = accountRepository;
			this.enviorment = enviorment;
			this.userManager = userManager;
			this.fileService = fileService;
		}

		public async Task<bool> EditUserAsync(EditUserViewModel model, string userId)
		{
			Guid userGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(userId, ref userGuid);
			if (!isGuidValid)
			{
				return false;
			}

			ApplicationUser? user = await this.accountRepository
				.GetByIdAsync(userGuid);

			if (user == null)
			{
				//TODO:Add message
				return false;
			}

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.AboutMe = model.AboutMe;
			user.Country = model.Country;

			if (model.UserName != null && model.UserName != user.UserName)
			{
				var result = await userManager.SetUserNameAsync(user, model.UserName);
				if (!result.Succeeded)
				{
					//TODO:Add message
					return false;
				}
				await userManager.UpdateNormalizedUserNameAsync(user);

			}
			if (model.Email != null && model.Email != user.Email)
			{
				var result = await userManager.SetEmailAsync(user, model.Email);
				if (!result.Succeeded)
				{
					//TODO:Add message
					return false;
				}
				await userManager.UpdateNormalizedEmailAsync(user);
			}



			await this.accountRepository.UpdateAsync(user);
			return true;
		}

		public async Task<bool> ChangePasswordAsync(string currentPassword, string newPassword, Guid userId)
		{
			var user = await userManager.FindByIdAsync(userId.ToString());

			if (user == null)
			{
				return false;
			}

			var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

			if (result.Succeeded)
			{
				return true;
			}

			return false;
		}


		public async Task<EditUserViewModel> GetEditUserViewAsync(Guid userId)
		{
			var model = await this.accountRepository
				.GetAllAttached()
				.Where(u => u.Id == userId)
				.Select(u => new EditUserViewModel()
				{
					FirstName = u.FirstName,
					LastName = u.LastName,
					AboutMe = u.AboutMe,
					Country = u.Country,
					UserName = u.UserName!,
					ProfilePicture = u.ProfilePricturePath
				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task<IndexGetUserInfoViewModel> IndexGetUserAsync(Guid userId)
		{
			var model = await this.accountRepository
				.GetAllAttached()
				.Where(u => u.Id == userId)
				.Select(u => new IndexGetUserInfoViewModel()
				{
					Id = userId.ToString(),
					FirstName = u.FirstName,
					LastName = u.LastName,
					UserName = u.UserName,
					CreatedOn = DateTime.Now,
					Country = u.Country,
					AboutMe = u.AboutMe,
					Email = u.Email!,
					ProfilePricture = u.ProfilePricturePath,
					UserAddedRecepies = u.AddedRecepies
					.Where(r => r.IsDeleted == false)
					.Select(r => new UserAddedRecepiesViewModel
					{
						Id = r.Id.ToString(),
						Name = r.Name,
						DificultyLevel = r.RecepieDificulty.DificultyName,
						Categodry = r.RecepieCategory.Name,
						Image = r.ImageURL,
						AddedOn = r.CreatedOn.ToString(DateTimeFormat),
						Likes = r.UsersRecepies.Count(),
						Comments = r.RecepieComments.Count()
					})
				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> UpdateProfilePictureAsync(IFormFile file, Guid userId)
		{
			ApplicationUser? user = await this.accountRepository
				.GetByIdAsync(userId);

			if (user == null)
			{
				//TODO:Add message
				return false;
			}

			if (file != null)
			{
				if (user.ProfilePricturePath != null)
				{
					fileService.DeleteFile(user.ProfilePricturePath);
				}

				string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
				long maxSize = 5 * 1024 * 1024;
				if (!fileService.IsFileValid(file, allowedExtensions, maxSize))
				{
					throw new ArgumentException(InvalidFileMessage);

				}

				string fileName = userId.ToString() + "_" + user.UserName + "_" + Path.GetFileName(file.FileName);
				string newImagePath = await fileService.UploadFileAsync(file, ProfilePicturesFolderName, fileName);

				user.ProfilePricturePath = newImagePath;

				await this.accountRepository.UpdateAsync(user);
				return true;
			}
			return false;
		}

	}
}
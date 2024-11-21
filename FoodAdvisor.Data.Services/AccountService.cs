using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.AccountViemModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodAdvisor.Data.Services
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly IRepository<ApplicationUser, Guid> accountRepository;
		private readonly IWebHostEnvironment enviorment;
		public AccountService(IRepository<ApplicationUser, Guid> accountRepository, IWebHostEnvironment enviorment)
        {
			this.accountRepository = accountRepository;
			this.enviorment = enviorment;
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
			user.Birthday = model.BirthDay;
			user.UserName = model.UserName;
			user.NormalizedUserName = model.UserName.ToUpper();

			await this.accountRepository.UpdateAsync(user);
			return true;
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
					BirthDay = u.Birthday,
					AboutMe = u.AboutMe,
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
					CreatedOn = DateTime.Now,
					BirthDay = DateTime.Now,
					AboutMe = u.AboutMe,
					Email = u.Email,
					ProfilePricture = u.ProfilePricturePath,
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
					string filePath = enviorment.WebRootPath;
					string imageToDelete = $"{filePath}\\{user.ProfilePricturePath}";

					File.Delete(imageToDelete);
				}

				string fileName = userId.ToString() + "_" + user.UserName + "_" + Path.GetFileName(file.FileName);
				string NewImagePath = Path.Combine("ProfilePictures", fileName);

				using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, NewImagePath), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				user.ProfilePricturePath = NewImagePath;


				await this.accountRepository.UpdateAsync(user);
			}
			return true;
		}
	}
}

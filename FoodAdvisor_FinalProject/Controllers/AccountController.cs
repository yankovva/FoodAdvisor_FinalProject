using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.ViewModels.AccountViemModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.IO;
using static FoodAdvisor.Common.EntityValidationConstants;

namespace FoodAdvisor_FinalProject.Controllers
{
	[Authorize]
	public class AccountController : BaseController
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly IWebHostEnvironment enviorment;
		public AccountController(FoodAdvisorDbContext dbContext, IWebHostEnvironment enviorment)
		{
			this.dbContext = dbContext;
			this.enviorment = enviorment;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			var model = await this.dbContext
				.Users
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
			if (model == null)
			{
				//TODO add error
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);

			var model = await this.dbContext
				.Users
				.Where(u => u.Id == userId)
				.Select(u => new EditUserViewModel()
				{

					FirstName = u.FirstName,
					LastName = u.LastName,
					BirthDay = u.Birthday,
					AboutMe = u.AboutMe,
					ProfilePricturePath = u.ProfilePricturePath,
					UserName = u.UserName!
				}).FirstOrDefaultAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditUserViewModel model, string id, IFormFile file)
		{
			Guid userGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref userGuid);
			if (!isGuidValid)
			{
				return RedirectToAction(nameof(Index));
			}

			if (ModelState.IsValid == false)
			{
				return RedirectToAction(nameof(Index));
			}

			ApplicationUser? user = await this.dbContext
				.Users
				.FindAsync(userGuid);

			if (user == null)
			{
				//TODO:Add message
				return RedirectToAction(nameof(Index));
			}

			string uploadFolder = Path.Combine(enviorment.WebRootPath, "ProfilePictures");

			if (!Directory.Exists(uploadFolder))
			{
				Directory.CreateDirectory(uploadFolder);
			}

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.AboutMe = model.AboutMe;
			user.Birthday = model.BirthDay;
			user.UserName = model.UserName;
			user.NormalizedUserName = model.UserName.ToUpper();

			if (file != null)
			{
				string filePath = enviorment.WebRootPath;
				string imageToDelete = $"{filePath}\\{user.ProfilePricturePath}";

				System.IO.File.Delete(imageToDelete);

				string fileName = Path.GetFileName(file.FileName);
				string NewImagePath = Path.Combine("ProfilePictures", fileName);

				using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, NewImagePath), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				user.ProfilePricturePath = NewImagePath;
			}

			await this.dbContext.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> UpdateImage(IFormFile file)
		{
			string userId =  GetCurrentUserId()!;
			Guid userGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(userId, ref userGuid);
			if (!isGuidValid)
			{
				return RedirectToAction(nameof(Index));
			}

			ApplicationUser? user = await this.dbContext
				.Users
				.FindAsync(userGuid);

			if (user == null)
			{
				//TODO:Add message
				return RedirectToAction(nameof(Index));
			}
			
			if (file != null)
			{
				string filePath = enviorment.WebRootPath;
				string imageToDelete = $"{filePath}\\{user.ProfilePricturePath}";
				System.IO.File.Delete(imageToDelete);

				string fileName = Path.GetFileName(file.FileName);
				string NewImagePath = Path.Combine("ProfilePictures", fileName);

				using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, NewImagePath), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				user.ProfilePricturePath = NewImagePath;

				await this.dbContext.SaveChangesAsync();
			}
			

			return RedirectToAction(nameof(Index));
		}
	}
	
}

using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.AccountViemModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Common.ErrorMessages;

namespace FoodAdvisor_FinalProject.Controllers
{
    [Authorize]
	public class AccountController : BaseController
	{
		private readonly IAccountService accountService;
		
		public AccountController(IAccountService accountService)
		{
			this.accountService = accountService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = "An unexpected error occurred. Please try again later or contact support.";
                return RedirectToAction("Index", "Home");
			}

			var model = await this.accountService
				.IndexGetUserAsync(userId);

			if (model == null)
			{
				TempData[ErrorMessage] = "No user found with the provided details. Please check your information and try again.";

                return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);

			var model = await this.accountService
				.GetEditUserViewAsync(userId);

			if (model == null)
			{
                TempData[ErrorMessage] = "No user found with the provided details. Please check your information and try again.";
                return  RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditUserViewModel model, string id)
		{
			if (ModelState.IsValid == false)
			{
				TempData[ErrorMessage]= "The data provided is invalid. Please ensure all fields are filled out correctly and try again.";

                return View(model);
			}

			bool isEdited = await this.accountService
				.EditUserAsync(model, id);

			if (isEdited == false)
			{
                TempData[ErrorMessage] = "An unexpected error occurred. Please try again later or contact support.";
                return View(model);
            }

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> UpdateImage(IFormFile file)
		{
			try
			{
                Guid userGuid = Guid.Parse(GetCurrentUserId()!);

                bool isUpdated = await this.accountService
                    .UpdateProfilePictureAsync(file, userGuid);

                if (isUpdated == false)
                {
                    TempData[ErrorMessage] = "Unable to update the profile picture.User not found";
					return RedirectToAction(nameof(Index));
				}

                TempData[SuccessMessage] = "Profile picture updated successfully.";
            }
			catch (ArgumentException ex)
			{
                TempData[ErrorMessage] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

		
	}
}
	


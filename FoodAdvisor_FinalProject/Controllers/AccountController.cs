using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.AccountViemModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Principal;
using static FoodAdvisor.Common.EntityValidationConstants;
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
				TempData[ErrorMessage] = GeneralErrorMessage;
                return RedirectToAction("/Identity/Account/Login");
			}

			var model = await this.accountService
				.IndexGetUserAsync(userId);

			if (model == null)
			{
				TempData[ErrorMessage] = EntityNotFoundMessage;

                return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			Guid userId = Guid.Parse(this.GetCurrentUserId()!);
			if (userId == Guid.Empty)
			{
				TempData[ErrorMessage] = GeneralErrorMessage;
				return RedirectToAction("/Identity/Account/Login");
			}

			var model = await this.accountService
				.GetEditUserViewAsync(userId);

			if (model == null)
			{
                TempData[ErrorMessage] = InvalidGuidMessage;
                return  RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditUserViewModel model, string id)
		{
			if (ModelState.IsValid == false)
			{
				TempData[ErrorMessage]= InvalidModelStateErrorMessage;

                return View(model);
			}

			bool isEdited = await this.accountService
				.EditUserAsync(model, id);

			if (isEdited == false)
			{
                TempData[ErrorMessage] = UnexpectedErrorMessage;
                return View(model);
            }

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateImage(IFormFile file)
		{
			try
			{
				Guid userId = Guid.Parse(this.GetCurrentUserId()!);
				if (userId == Guid.Empty)
				{
					TempData[ErrorMessage] = GeneralErrorMessage;
					return RedirectToAction("/Identity/Account/Login");
				}

				bool isUpdated = await this.accountService
                    .UpdateProfilePictureAsync(file, userId);

                if (isUpdated == false)
                {
                    TempData[ErrorMessage] = EntityNotFoundMessage;
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
	


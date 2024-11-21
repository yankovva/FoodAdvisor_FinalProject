using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
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
				//TODO add error
				return RedirectToAction("Index", "Home");
			}

			var model = await this.accountService
				.IndexGetUserAsync(userId);

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

			var model = await this.accountService
				.GetEditUserViewAsync(userId);

			if (model == null)
			{
				return  RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditUserViewModel model, string id)
		{
			if (ModelState.IsValid == false)
			{
				return RedirectToAction(nameof(Index));
			}

			bool isEdited = await this.accountService
				.EditUserAsync(model, id);

			if (isEdited == false)
			{
				//TODO: add message
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> UpdateImage(IFormFile file)
		{
			Guid userGuid =  Guid.Parse(GetCurrentUserId()!);

			bool isUpdated =  await this.accountService
				.UpdateProfilePictureAsync(file, userGuid);

			if (isUpdated == false)
			{
				//TODO: add message
				return RedirectToAction("Index", "Home");
			}
			
			return RedirectToAction(nameof(Index));
		}
	}
	
}

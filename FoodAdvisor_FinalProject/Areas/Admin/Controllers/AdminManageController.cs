using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.UserViewModels;
using FoodAdvisor_FinalProject.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Common.ApplicationConstants;

namespace FoodAdvisor_FinalProject.Areas.Admin.Controllers
{
	[Area(AdminRoleName)]
	[Authorize(Roles = AdminRoleName)]
	public class AdminManageController : BaseController
	{
		private readonly IUserService userService;
		public AdminManageController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var users = await this.userService.GetAllUsersAsync();
			return this.View(users);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateRole(string userId, string roleName)
		{
			Guid userGuid = Guid.Empty;
			if (!this.IsGuidValid(userId, ref userGuid))
			{
				return this.RedirectToAction(nameof(Index));
			}

			var isUpdated = await this.userService.UpdateRoleAsync(userGuid, roleName);
			if (isUpdated == false)
			{
				return this.RedirectToAction(nameof(Index), "Home");
			}

			return this.RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RemoveRole(string userId, string roleName)
		{
			Guid userGuid = Guid.Empty;
			if (!this.IsGuidValid(userId, ref userGuid))
			{
				return this.RedirectToAction(nameof(Index));
			}

			bool isRemoved = await this.userService.RemoveRoleAsync(userGuid, roleName);
			if (isRemoved == false)
			{
				return RedirectToAction(nameof(Index));
			}
			return RedirectToAction(nameof(Index));

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(string userId)
		{
			Guid userGuid = Guid.Empty;
			if (!this.IsGuidValid(userId, ref userGuid))
			{
				return this.RedirectToAction(nameof(Index));
			}
			bool isDelted = await this.userService.DeleteUserAsync(userGuid);
			if (isDelted == false)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.RedirectToAction(nameof(Index));
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RemoveManager(string userId)
		{
			Guid userGuid = Guid.Empty;
			if (!this.IsGuidValid(userId, ref userGuid))
			{
				return this.RedirectToAction(nameof(Index));
			}
			bool isRemoved = await this.userService
				.RemoveManagerAsync(userGuid);

			if (isRemoved == false)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.RedirectToAction(nameof(Index));
		}


		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateManager([FromForm] ManagerFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return Json(new
				{
					success = false,
					errors = ModelState.Values
					.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
				});
			}
			bool result = await this.userService.MakeManagerAsync(model.UserId, model.PhoneNumber, model.Address);

			if (result == false)
			{
				return Json(new
				{
					success = false,
					errors = ModelState.Values
					.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
				});
			}
			return Json(new { success = true });
		}
	}
}


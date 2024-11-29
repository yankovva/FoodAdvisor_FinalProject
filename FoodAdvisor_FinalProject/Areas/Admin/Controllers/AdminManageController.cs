using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor_FinalProject.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodAdvisor.Common.ApplicationConstants;
using static FoodAdvisor.Common.EntityValidationConstants;

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
        public async Task<IActionResult> RemoveRole (string userId, string roleName)
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
        public async Task<IActionResult> MakeManager(string userId)
        {
            Guid userGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool isMadeManager = await this.userService
                .MakeManagerAsync(userGuid);

            if (isMadeManager == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index));
        }
		[HttpPost]
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
	}
}

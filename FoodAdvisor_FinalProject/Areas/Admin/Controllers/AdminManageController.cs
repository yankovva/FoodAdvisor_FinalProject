using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor_FinalProject.Controllers;
using Microsoft.AspNetCore.Authorization;
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
    }
}

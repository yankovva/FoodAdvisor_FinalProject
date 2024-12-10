using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor.Data.Services
{
    public class UserService : BaseService, IUserService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly IManagerService managerService;

		public UserService(UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole<Guid>> roleManager,
			IManagerService managerService)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.managerService = managerService;
		}

		public async Task<bool> DeleteUserAsync(Guid userId)
		{
			ApplicationUser? user = await userManager
			   .FindByIdAsync(userId.ToString());

			if (user == null)
			{
				return false;
			}

			IdentityResult? result = await this.userManager
				.DeleteAsync(user);
			if (!result.Succeeded)
			{
				return false;
			}

			return true;
		}

		public async Task<IEnumerable<IndexAllUsersViewModel>> GetAllUsersAsync()
		{
			IEnumerable<ApplicationUser> allUsers = await this.userManager.Users
			   .ToArrayAsync();

			ICollection<IndexAllUsersViewModel> allUsersViewModel = new List<IndexAllUsersViewModel>();

			foreach (ApplicationUser user in allUsers)
			{
				var userId = user.Id.ToString();
				bool isManager = await this.managerService.IsUserManagerAsync(userId);
				allUsersViewModel.Add(new IndexAllUsersViewModel()
				{
					Id = userId,
					Email = user.Email,
					Username = user.UserName,
					IsManager = isManager,
					CurrentRoles = userManager.GetRolesAsync(user).Result.ToList(),
				});
			}


			return allUsersViewModel;
		}

		public async Task<bool> UpdateRoleAsync(Guid userId, string roleName)
		{
			ApplicationUser? user = await userManager
				.FindByIdAsync(userId.ToString());

			bool roleExists = await this.roleManager
				.RoleExistsAsync(roleName);

			if (user == null || roleExists == false)
			{
				return false;
			}

			bool userIsInRole = await this.userManager.IsInRoleAsync(user, roleName);
			if (userIsInRole == false)
			{
				var result = await this.userManager
					.AddToRoleAsync(user, roleName);

				if (result.Succeeded == false)
				{
					return false;
				}
			}
			return true;
		}

		public async Task<bool> RemoveRoleAsync(Guid userId, string roleName)
		{
			ApplicationUser? user = await userManager
				.FindByIdAsync(userId.ToString());

			bool roleExists = await this.roleManager
				.RoleExistsAsync(roleName);

			if (user == null || roleExists == false)
			{
				return false;
			}

			bool userIsInTheRole = await this.userManager.IsInRoleAsync(user, roleName);
			if (userIsInTheRole)
			{
				var result = await this.userManager
					.RemoveFromRoleAsync(user, roleName);

				if (result.Succeeded == false)
				{
					return false;
				}
			}

			return true;
		}

		public async Task<bool> MakeManagerAsync(string userId, string phoneNumber, string address)
		{
			ApplicationUser? user = await userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return false;
			}

			bool alreadyManager = await this.managerService.IsUserManagerAsync(userId);
			if (alreadyManager == true)
			{
				return false;
			}

			await this.managerService.AddManagerAsync(user.Id, phoneNumber, address);
			return true;

		}

		public async Task<bool> RemoveManagerAsync(Guid userId)
		{
			ApplicationUser? user = await userManager
				.FindByIdAsync(userId.ToString());

			bool isManager = await this.managerService.IsUserManagerAsync(userId.ToString());
			if (user == null || isManager == false)
			{
				return false;
			}

			bool isDeleted = await this.managerService.RemoveManagerAsync(userId);
			if (isDeleted == false)
			{
				return false;
			}
			return true;
		}




	}
}

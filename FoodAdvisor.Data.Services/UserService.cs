using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IEnumerable<IndexAllUsersViewModel>> GetAllUsersAsync()
        {
            IEnumerable<ApplicationUser> allUsers = await this.userManager.Users
               .ToArrayAsync();

            ICollection<IndexAllUsersViewModel> allUsersViewModel = new List<IndexAllUsersViewModel>();

            foreach (ApplicationUser user in allUsers)
            {
                allUsersViewModel.Add(new IndexAllUsersViewModel()
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Username = user.UserName,
                    CurrentRoles = userManager.GetRolesAsync(user).Result.ToList()
                });
            }

            return allUsersViewModel;
        }
    }
}

using FoodAdvisor.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<IndexAllUsersViewModel>> GetAllUsersAsync();
    }
}

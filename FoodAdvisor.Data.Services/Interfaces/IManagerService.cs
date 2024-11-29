using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IManagerService
	{
		Task<bool> IsUserManagerAsync(string userId);
		Task AddManagerAsync(Guid userId, string phoneNumber, string address);
		Task<bool> RemoveManagerAsync(Guid userId);
	}
}

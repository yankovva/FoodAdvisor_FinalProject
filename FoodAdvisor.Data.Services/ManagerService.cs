using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
	public class ManagerService : BaseService, IManagerService
	{

		private readonly IRepository<Manager, Guid> managerRepository;
		public ManagerService(IRepository<Manager, Guid> managerRepository)
		{
			this.managerRepository = managerRepository;
		}
		public async Task<bool> IsUserManagerAsync(string userId)
		{
			if (string.IsNullOrWhiteSpace(userId))
			{
				return false;
			}
			bool result = await this.managerRepository
				.GetAllAttached()
				.AnyAsync(m => m.UserId.ToString().ToLower() == userId);
			return result;
		}
	}
}

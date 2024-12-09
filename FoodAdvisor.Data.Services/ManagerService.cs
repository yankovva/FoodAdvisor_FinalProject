using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


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

		public async Task AddManagerAsync(Guid userId, string phoneNumber, string address)
		{
			Manager manager = new Manager()
			{
				UserId = userId,
				Address = address,
				WorkPhoneNumber = phoneNumber
			};

			await this.managerRepository.AddAsync(manager);
		}

		public async Task<bool> RemoveManagerAsync(Guid userId)
		{
			Manager manager = await this.managerRepository
				.FirstorDefaultAsync(m=>m.UserId == userId);

			if (manager == null)
			{
				return false;
			}

			bool isDeleted = await this.managerRepository.DeleteAsync(manager.Id);
			if (isDeleted == false)
			{
				return false;
			}

			return true;
		}

	}
}

using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
	public class RecepieService: BaseService, IRecepieService
	{
		private readonly IRepository<Recepie, Guid> recepieRepository;
        public RecepieService(IRepository<Recepie, Guid> recepieRepository)
        {
                this.recepieRepository = recepieRepository;
        }

		public async Task<IEnumerable<RecepieIndexViewModel>> IndexGetAllRecepiesAsync()
		{
			IEnumerable<RecepieIndexViewModel> recepies = await this.recepieRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false)
				.Select(r => new RecepieIndexViewModel()
				{
					Id = r.Id.ToString(),
					Name = r.Name,
					CookingTime = r.CookingTime,
					ImageURL = r.ImageURL,
					Publisher = r.Publisher.UserName
				})
				.ToArrayAsync();

			return recepies;
		}
	}
}

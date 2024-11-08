using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.FavouritesViewModel;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
	public class RecepieFavouritesService : BaseService, IRecepieFavouritesService
	{
		private IRepository<Recepie, Guid> recepietRepository;
		private IRepository<UserRecepie, object> userRecepieRepository;


		public RecepieFavouritesService(IRepository<Recepie, Guid> recepietRepository,
			IRepository<UserRecepie, object> userRecepieRepository)
		{
			this.recepietRepository = recepietRepository;
			this.userRecepieRepository = userRecepieRepository;
		}
		public async Task<IEnumerable<RecepieFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId)
		{
			IEnumerable<RecepieFavouritesIndexViewModel> recepies = await this.userRecepieRepository
				.GetAllAttached()
			   .Where(ur => ur.Recepie.IsDeleted == false && ur.ApplicationUserId.ToString().ToLower() == userId.ToLower())
			   .Select(ur => new RecepieFavouritesIndexViewModel()
			   {
				   Id = ur.RecepieId.ToString(),
				   Name = ur.Recepie.Name,
				   Description = ur.Recepie.Description,
				   CookingTime = ur.Recepie.CookingTime,
				   ImageUrl = ur.Recepie.ImageURL ?? string.Empty
			   })
			   .ToArrayAsync();

			return recepies;
		}
	}
}

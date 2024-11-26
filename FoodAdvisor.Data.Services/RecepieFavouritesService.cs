using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> AddToFavouritesAsync(Guid userId, string recepieId)
        {
            Guid recepieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
            if (!isGuidValid)
            {
                return false;
            }

            Recepie? recepie = await this.recepietRepository
               .GetAllAttached()
               .Where(r => r.IsDeleted == false)
               .FirstOrDefaultAsync(r => r.Id == recepieGuid);

            if (recepie == null)
            {
                return false;
            }

            bool alreaduAddedToFavourites = await this.userRecepieRepository
                .GetAllAttached()
                .AnyAsync(ur => ur.ApplicationUserId == userId && ur.RecepieId == recepieGuid);

            UserRecepie newFavoriteRecepie = new UserRecepie();

            if (alreaduAddedToFavourites == false)
            {
                newFavoriteRecepie.ApplicationUserId = userId;
                newFavoriteRecepie.RecepieId = recepieGuid;

                await this.userRecepieRepository.AddAsync(newFavoriteRecepie!);
                return true;
            }

            return false;
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
				   Description = ur.Recepie.Description.Substring(0, 120),
                   CookingTime = ur.Recepie.CookingTime,
				   ImageUrl = ur.Recepie.ImageURL ?? string.Empty,
				   Category = ur.Recepie.RecepieCategory.Name,
				   Servings = ur.Recepie.NumberOfServing
			   })
			   .ToArrayAsync();

			return recepies;
		}

		public async Task<bool> RemoveFromFavouritesAsync(Guid userId, string recepieId)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
			if (!isGuidValid)
			{
				return false;
			}
			Recepie? recepie = await this.recepietRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false)
				.FirstOrDefaultAsync(r => r.Id == recepieGuid);

			if (recepie == null)
			{
				return false;
			}

			UserRecepie? userRecepie = await this.userRecepieRepository
			  .FirstorDefaultAsync(ur => ur.ApplicationUserId == userId && ur.RecepieId == recepieGuid);

			if (userRecepie == null)
			{
				return false;
			}

			await this.userRecepieRepository.DeleteAsync(userRecepie);
			return true;
		}
	}
}

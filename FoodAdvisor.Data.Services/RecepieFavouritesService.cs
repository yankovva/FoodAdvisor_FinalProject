using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepieFavouritesViewModels;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ErrorMessages;

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

            if (alreaduAddedToFavourites == true)
            {
				throw new Exception(FavoritesErrorMessage);
				
            }
			newFavoriteRecepie.ApplicationUserId = userId;
			newFavoriteRecepie.RecepieId = recepieGuid;

			await this.userRecepieRepository.AddAsync(newFavoriteRecepie!);
			return true;
        }

		public async Task<int> GetFilteredRecepiesCountAsync(string userId,RecipeFavouritesFilteredViewModel inputModel)
		{
			RecipeFavouritesFilteredViewModel model = new RecipeFavouritesFilteredViewModel()
			{
				CurrentPage = null,
				EntitiesPerPage = null,
				SearchQuery = inputModel.SearchQuery,
				CategoryFilter = inputModel.CategoryFilter,
				DificultyFilter = inputModel.DificultyFilter,
			};
			int recipesCount = (await this.InedexGetAllFavouritesAsync(userId,model))
				.Count();

			return recipesCount;
		}

		public async Task<IEnumerable<RecepieFavouritesIndexViewModel>> InedexGetAllFavouritesAsync(string userId, RecipeFavouritesFilteredViewModel model)
		{
			IQueryable<UserRecepie> allRecipes = this.userRecepieRepository
				.GetAllAttached();

			if (!String.IsNullOrWhiteSpace(model.SearchQuery))
			{
				allRecipes = allRecipes
					.Where(m => m.Recepie.Name.ToLower().Contains(model.SearchQuery.ToLower()));
			}

			if (!String.IsNullOrWhiteSpace(model.CategoryFilter))
			{
				allRecipes = allRecipes
					.Where(m => m.Recepie.RecepieCategory.Name.ToLower() == model.CategoryFilter.ToLower());
			}

			if (!String.IsNullOrWhiteSpace(model.DificultyFilter))
			{
				allRecipes = allRecipes
					.Where(m => m.Recepie.RecepieDificulty.DificultyName.ToLower() == model.DificultyFilter.ToLower());
			}


			if (model.CurrentPage.HasValue &&
				model.EntitiesPerPage.HasValue)
			{
				allRecipes = allRecipes
					.Skip(model.EntitiesPerPage.Value * (model.CurrentPage.Value - 1))
					.Take(model.EntitiesPerPage.Value);

			}
			IEnumerable<RecepieFavouritesIndexViewModel> recepies = await allRecipes
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

		public async Task<IEnumerable<string>> GetAllCategoriesAsync()
		{
			IEnumerable<string> allCategories = await this.userRecepieRepository
				.GetAllAttached()
				.Select(c => c.Recepie.RecepieCategory.Name)
				.Distinct()
				.ToArrayAsync();

			return allCategories;
		}

		public async Task<IEnumerable<string>> GetAllDificultiesAsync()
		{
			IEnumerable<string> allDificulties = await this.userRecepieRepository
				.GetAllAttached()
				.Select(c => c.Recepie.RecepieDificulty.DificultyName)
				.Distinct()
				.ToArrayAsync();

			return allDificulties;
		}

	}
}

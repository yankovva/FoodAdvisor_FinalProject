using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor.Data.Services
{
	public class RecepieService: BaseService, IRecepieService
	{
		private readonly IRepository<Recepie, Guid> recepieRepository;
        public RecepieService(IRepository<Recepie, Guid> recepieRepository)
        {
                this.recepieRepository = recepieRepository;
        }

		public async Task AddRecepiesAsync(AddRecepieViewModel model, Guid userId)
		{
			Recepie recepie = new Recepie()
			{
				Name = model.Name,
				Description = model.Description,
				ImageURL = model.ImageURL,
				CookingTime = model.CookingTime,
				PublisherId = userId,
				CreatedOn = DateTime.Now
			};

			await this.recepieRepository.AddAsync(recepie);
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
		 public async Task<DetailsRecepieViewModel> GetRecepietDetailsAsync(Guid recepieId)
		{
			DetailsRecepieViewModel? model =await this.recepieRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false && r.Id == recepieId)
				.Select(r => new DetailsRecepieViewModel()
				{
					Id = recepieId,
					Name = r.Name,
					Description = r.Description,
					CreatetOn = r.CreatedOn,
					CookingTime = r.CookingTime,
					Publisher = r.Publisher.UserName!,
					ImageURL = r.ImageURL

				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task<DeleteRecepieViewModel> DeleteRestaurantViewAsync(Guid recepieId)
		{

			DeleteRecepieViewModel? model = await this.recepieRepository
				.GetAllAttached()
			   .Where(r => r.Id == recepieId && r.IsDeleted == false)
			   .AsNoTracking()
			   .Select(r => new DeleteRecepieViewModel()
			   {
				   Id = recepieId.ToString(),
				   Name = r.Name,
				   Publisher = r.Publisher.UserName ?? string.Empty,
				   CreatedOn = r.CreatedOn
			   })
			   .FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> DeleteRestaurantAsync(DeleteRecepieViewModel model)
		{
			Recepie? recepie = await this.recepieRepository
				.GetByIdAsync(Guid.Parse(model.Id));

			if (recepie != null)
			{
				recepie.IsDeleted = true;
				await this.recepieRepository.SaveChangesAsync();
				return true;
			}
			return false;

		}
	}
}

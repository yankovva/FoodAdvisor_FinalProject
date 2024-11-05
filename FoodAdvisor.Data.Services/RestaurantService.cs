using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor.Data.Services
{
    public class RestaurantService : IRestaurantService
	{
		private IRepository<Restaurant, Guid> restaurantRepository;
	
		public RestaurantService(IRepository<Restaurant, Guid> restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
			
        }

		//TODO:
        public async Task AddRestaurantAsync(RestaurantAddViewModel model)
		{

			//Restaurant place = new Restaurant()
			//{
			//	Name = model.Name,
			//	Description = model.Description,
			//	ImageURL = model.ImageURL,
			//	CategoryId = model.CategoryId,
			//	PublisherId = userManager.,
			//	CityId = model.CityId,
			//	Address = model.Address,
			//};

			//await this.restaurantRepository.AddAsync(place);
		}

		//Done
		public async Task DeleteRestaurantAsync(RestaurantDeleteViewModel model)
		{
			Restaurant? restaurant = await this.restaurantRepository
				.GetAllAttached()
			   .Where(g => g.Id == Guid.Parse(model.Id))
			   .Where(g => g.IsDeleted == false)
			   .FirstOrDefaultAsync();
			
			if (restaurant != null)
			{
				 restaurant.IsDeleted = true;
				await this.restaurantRepository.SaveChangesAsync();
			}

		}

		//Done
		public async Task<RestaurantDeleteViewModel> DeleteRestaurantViewAsync(Guid id)
		{
			RestaurantDeleteViewModel? model = await this.restaurantRepository
				.GetAllAttached()
			   .Where(r => r.Id == id && r.IsDeleted == false)
			   .AsNoTracking()
			   .Select(r => new RestaurantDeleteViewModel()
			   {
				   Id = id.ToString(),
				   Name = r.Name,
				   Publisher = r.Publisher.UserName ?? string.Empty,
				   Category = r.Category.Name
			   })
			   .FirstOrDefaultAsync();

			return model;
		}

		//TODO:
		public async Task EditRestaurantAsync(Guid id)
		{

			Restaurant? editedRestaurant = await this.restaurantRepository
				.GetByIdAsync(id);
				
			if (editedRestaurant == null)
			{
				throw new ArgumentException("Invalid ID");
			}
			
			//editedRestaurant.Name = model.Name;
			//editedRestaurant.Address = model.Address;
			//editedRestaurant.ImageURL = model.ImageURL;
			//editedRestaurant.CategoryId = model.CategoryId;
			//editedRestaurant.PublisherId = Guid.Parse(GetCurrentUserId());
			//editedRestaurant.Description = model.Description;
			//editedRestaurant.CityId = model.CityId;

			//await this.dbContext.SaveChangesAsync();
		}

		//Done
		public async Task<RestaurantAddViewModel> EditRestaurantViewAsync(Guid id)
		{
			RestaurantAddViewModel? model = await this.restaurantRepository
				.GetAllAttached()
				.Where(r => r.Id == id && r.IsDeleted == false)
				.AsNoTracking()
				.Select(g => new RestaurantAddViewModel()
				{
					Name = g.Name,
					Description = g.Description,
					ImageURL = g.ImageURL,
					Address = g.Address

				})
				.FirstOrDefaultAsync();
			return model;
		}

		//Done
		public async Task<RestaurantDetailsViewModel> GetRestaurantDetailsAsync(Guid id)
		{
			 
			RestaurantDetailsViewModel? model = await this.restaurantRepository
				.GetAllAttached()
				.Where(p => p.Id == id && p.IsDeleted == false)
				.Select(p => new RestaurantDetailsViewModel()
				{
					Id = p.Id.ToString(),
					Name = p.Name,
					Description = p.Description,
					ImageURL = p.ImageURL,
					Address = p.Address,
					Category = p.Category.Name,
					City = p.City.Name,
					Publisher = p.Publisher.UserName ?? string.Empty,
					AllComment = p.RestaurantsComments
					.Select(rc=> new CommentAllViewModel()
					{
						Message = rc.Message,
						CreatedOn = rc.CreatedDate,
						UserId = rc.UserId.ToString(),
						Id = rc.Id.ToString(),
						UserName = rc.User.UserName ?? string.Empty
					})

				})
				.FirstOrDefaultAsync();

			return model;
		}

		//Done
		public async Task<IEnumerable<RestaurantIndexViewModel>> IndexGetAllRestaurants()
		{
			IEnumerable<RestaurantIndexViewModel> model = await this.restaurantRepository
			   .GetAllAttached()
			   .Where(r => r.IsDeleted == false)
			   .Select(p => new RestaurantIndexViewModel()
			   {
				   Id = p.Id.ToString(),
				   Name = p.Name,
				   ImageURL = p.ImageURL,
				   Category = p.Category.Name,
				   Publisher = p.Publisher.UserName ?? string.Empty
			   })
			   .ToArrayAsync();

			return model;
		}
	}
}

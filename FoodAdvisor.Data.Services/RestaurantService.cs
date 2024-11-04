using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services
{
	public class RestaurantService : IRestaurantService
	{
		private IRepository<Restaurant, Guid> restaurantRepository;
	
		public RestaurantService(IRepository<Restaurant, Guid> restaurantRepository,)
        {
            this.restaurantRepository = restaurantRepository;
			
        }

		//ToDo:
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

		public Task DeleteRestaurantAsync(RestaurantDeleteViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task<RestaurantDeleteViewModel> DeleteRestaurantViewAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<RestaurantAddViewModel> EditRestaurantasync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<RestaurantDetailsViewModel> GetRestaurantDetailsAsync(Guid id)
		{
			throw new NotImplementedException();
		}

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

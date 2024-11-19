using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Hosting;


namespace FoodAdvisor.Data.Services
{
    public class RestaurantService : BaseService,IRestaurantService
	{
		private IRepository<Restaurant, Guid> restaurantRepository;
		private IRepository<City, Guid> cityRepository;
		private readonly IWebHostEnvironment enviorment;

		public RestaurantService(IRepository<Restaurant, Guid> restaurantRepository,
			IRepository<City, Guid> cityRepository,
			IWebHostEnvironment enviorment)
        {
            this.restaurantRepository = restaurantRepository;
			this.cityRepository = cityRepository;
			this.enviorment = enviorment;
			
        }

		//Done
        public async Task AddRestaurantAsync(RestaurantAddViewModel model, Guid userId, IFormFile file)
		{
			string uploadFolder = Path.Combine(enviorment.WebRootPath, "RestaurantPictures");

			if (!Directory.Exists(uploadFolder))
			{
				Directory.CreateDirectory(uploadFolder);
			}

			string fileName = Path.GetFileName(file.FileName);
			string NemImagePath = Path.Combine("RestaurantPictures", fileName);

			using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, NemImagePath), FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			City? city = await this.cityRepository
				.GetAllAttached()
				.FirstOrDefaultAsync(c => c.Name.ToLower() == model.City.ToLower());
			if (city == null)
			{
				 city = new City()
				{
					Name = model.City
				};
				await this.cityRepository.AddAsync(city);

			}

			Restaurant place = new Restaurant()
			{
				Name = model.Name,
				Description = model.Description,
				ImageURL = NemImagePath,
				CategoryId = model.CategoryId,
				PublisherId = userId,
				City = city,
				Address = model.Address,
				PricaRange = model.PriceRange
			};

			await this.restaurantRepository.AddAsync(place);

		}

		//Done
		public async Task<bool> DeleteRestaurantAsync(RestaurantDeleteViewModel model)
		{
			Restaurant? restaurant = await this.restaurantRepository
				.GetByIdAsync(Guid.Parse(model.Id));

			string filePath = enviorment.WebRootPath;
			string imageToDelete = $"{filePath}\\{restaurant.ImageURL}";

			if (restaurant == null)
			{
				return false;
			}
			restaurant.IsDeleted = true;
			File.Delete(imageToDelete);
			await this.restaurantRepository.SaveChangesAsync();
			return true;
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
				   Category = r.Category.Name,
				   
			   })
			   .FirstOrDefaultAsync();

			return model;
		}

		//Done
		public async Task<bool> EditRestaurantAsync(RestaurantAddViewModel model, Guid restaurantId, Guid userId, IFormFile file)
		{
			Restaurant? editedRestaurant = await this.restaurantRepository
				.GetByIdAsync(restaurantId);
			if (editedRestaurant == null)
			{
				return false;
			}

			City city = new City()
			{
				Name = model.City
			};

			editedRestaurant.Name = model.Name;
			editedRestaurant.Address = model.Address;
			editedRestaurant.CategoryId = model.CategoryId;
			editedRestaurant.PublisherId = userId;
			editedRestaurant.Description = model.Description;
			editedRestaurant.City = city;
			editedRestaurant.PricaRange = model.PriceRange;

			if (file != null)
			{
				string filePath = enviorment.WebRootPath;
				string imageToDelete = $"{filePath}\\{editedRestaurant.ImageURL}";
				File.Delete(imageToDelete);

				string uploadFolder = Path.Combine(enviorment.WebRootPath, "RestaurantPictures");

				if (!Directory.Exists(uploadFolder))
				{
					Directory.CreateDirectory(uploadFolder);
				}

				string fileName = Path.GetFileName(file.FileName);
				string NemImagePath = Path.Combine("RestaurantPictures", fileName);

				using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, NemImagePath), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				editedRestaurant.ImageURL = NemImagePath;
			}
			await this.cityRepository.AddAsync(city);
			bool isUpdated = await this.restaurantRepository.UpdateAsync(editedRestaurant);
			return true;
			
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
					ImagePath = g.ImageURL,
					Address = g.Address,
					PriceRange = g.PricaRange
				})
				.FirstOrDefaultAsync();
			return model;
		}

		//Done
		public async Task<RestaurantDetailsViewModel> GetRestaurantDetailsAsync(Guid restaurnatId)
		{
			 
			RestaurantDetailsViewModel? model = await this.restaurantRepository
				.GetAllAttached()
				.Where(p => p.Id == restaurnatId && p.IsDeleted == false)
				.Select(p => new RestaurantDetailsViewModel()
				{
					Id = p.Id.ToString(),
					Name = p.Name,
					Description = p.Description,
					ImageURL = p.ImageURL,
					Address = p.Address,
					Category = p.Category.Name,
					PriceRange = p.PricaRange,
					City = p.City.Name,
					Publisher = p.Publisher.UserName ?? string.Empty,
					AllComment = p.RestaurantsComments
					.Where(rc=>rc.IsDeleted == false)
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
				   Publisher = p.Publisher.UserName ?? string.Empty,
				   PriceRange = p.PricaRange
			   })
			   .ToArrayAsync();

			return model;
		}
	}
}

using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using FoodAdvisor.ViewModels.CommentViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Hosting;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using FoodAdvisor.ViewModels;


namespace FoodAdvisor.Data.Services
{
	public class RestaurantService : BaseService, IRestaurantService
	{
		private readonly IRepository<Restaurant, Guid> restaurantRepository;
		private readonly IRepository<City, Guid> cityRepository;
		private readonly IRepository<RestaurantCuisine, Guid> cuisineRepository;
		private readonly IWebHostEnvironment enviorment;
		private readonly IFileService fileService;

		public RestaurantService(IRepository<Restaurant, Guid> restaurantRepository,
			IRepository<City, Guid> cityRepository,
			IWebHostEnvironment enviorment,
			IRepository<RestaurantCuisine, Guid> cuisineRepository, IFileService fileService)
		{
			this.restaurantRepository = restaurantRepository;
			this.cityRepository = cityRepository;
			this.enviorment = enviorment;
			this.cuisineRepository = cuisineRepository;
			this.fileService = fileService;
		}

		//Done
		public async Task AddRestaurantAsync(RestaurantAddViewModel model, Guid userId, IFormFile file, IFormFile fileDish)
		{
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			long maxSize = 5 * 1024 * 1024; // 5MB

			string fileName = userId.ToString() + "_" + model.Name + "_" + Path.GetFileName(file.FileName);
			string fileNameChefsDish = userId.ToString() + "_" + model.ChefsDishName + "_" + Path.GetFileName(fileDish.FileName);

			string filePathREstaurant = await fileService.UploadFileAsync(file, "RestaurantPictures", fileName);
			string filePathChefDish = await fileService.UploadFileAsync(file, "ChefDishesPictures", fileName);


			City city = await this.cityRepository
				.FirstorDefaultAsync(c => c.Name.ToLower() == model.City.ToLower());
			if (city == null)
			{
				city = new City()
				{
					Name = model.City
				};
				await cityRepository.AddAsync(city);
			}
			RestaurantCuisine cuisine = await this.cuisineRepository
				.FirstorDefaultAsync(c => c.Name.ToLower() == model.CuisineName.ToLower());

			if (cuisine == null)
			{
				cuisine = new RestaurantCuisine()
				{
					Name = model.CuisineName
				};
				await cuisineRepository.AddAsync(cuisine);
			}


			Restaurant place = new Restaurant()
			{
				Name = model.Name,
				Description = model.Description,
				ImageURL = filePathREstaurant,
				CategoryId = model.CategoryId,
				PublisherId = userId,
				City = city,
				Address = model.Address,
				PricaRange = model.PriceRange,
				MenuDescription = model.MenuDescription,
				AtmosphereDescription = model.AtmosphereDescription,
				ChefsSpecial = model.ChefsDishName,
				ChefsSpecialImage = filePathChefDish,
				Cuisine = cuisine
			};

			await this.restaurantRepository.AddAsync(place);

		}

		//Done
		public async Task<bool> DeleteRestaurantAsync(RestaurantDeleteViewModel model)
		{
			Restaurant? restaurant = await this.restaurantRepository
				.GetByIdAsync(Guid.Parse(model.Id));

			if (restaurant == null)
			{
				return false;
			}
			this.fileService.DeleteFile(restaurant.ImageURL);
			restaurant.IsDeleted = true;
			await restaurantRepository.SaveChangesAsync();
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
		public async Task<bool> EditRestaurantAsync(RestaurantAddViewModel model, Guid restaurantId, Guid userId, IFormFile file, IFormFile fileDish)
		{
			Restaurant? editedRestaurant = await this.restaurantRepository
				.GetByIdAsync(restaurantId);

			if (editedRestaurant == null)
			{
				return false;
			}

			City city = await this.cityRepository
				.FirstorDefaultAsync(c => c.Name.ToLower() == model.City.ToLower());
			if (city == null)
			{
				city = new City()
				{
					Name = model.City
				};
				await cityRepository.AddAsync(city);
			}

			RestaurantCuisine cuisine = await this.cuisineRepository
				.FirstorDefaultAsync(c => c.Name.ToLower() == model.CuisineName.ToLower());

			if (cuisine == null)
			{
				cuisine = new RestaurantCuisine()
				{
					Name = model.CuisineName
				};
				await cuisineRepository.AddAsync(cuisine);
			}

			editedRestaurant.Name = model.Name;
			editedRestaurant.Address = model.Address;
			editedRestaurant.CategoryId = model.CategoryId;
			editedRestaurant.PublisherId = userId;
			editedRestaurant.Description = model.Description;
			editedRestaurant.City = city;
			editedRestaurant.Cuisine = cuisine;
			editedRestaurant.PricaRange = model.PriceRange;
			editedRestaurant.MenuDescription = model.MenuDescription;
			editedRestaurant.AtmosphereDescription = model.AtmosphereDescription;
			editedRestaurant.ChefsSpecial = model.ChefsDishName;

			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			long maxSize = 5 * 1024 * 1024;
			if (file != null)
			{
				fileService.DeleteFile(editedRestaurant.ImageURL);

				if (!fileService.IsFileValid(file, allowedExtensions, maxSize))
				{
					throw new ArgumentException("Unvalid file!");
				}

				string fileName = $"{userId}_{model.Name}_{Path.GetFileName(file.FileName)}";
				string newImagePath = await fileService.UploadFileAsync(file, "RestaurantPictures", fileName);

				editedRestaurant.ImageURL = newImagePath;
			}

			if (fileDish != null)
			{
				fileService.DeleteFile(editedRestaurant.ChefsSpecialImage);

				if (!fileService.IsFileValid(fileDish, allowedExtensions, maxSize))
				{
					throw new ArgumentException("Unvalid file!");
				}

				string fileName = $"{userId}_{model.Name}_{Path.GetFileName(fileDish.FileName)}";
				string newImagePath = await fileService.UploadFileAsync(fileDish, "ChefDishesPictures", fileName);
				
				editedRestaurant.ChefsSpecialImage = newImagePath;
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
					PriceRange = g.PricaRange,
					MenuDescription = g.MenuDescription,
					AtmosphereDescription = g.AtmosphereDescription,
					ChefsDishName = g.ChefsSpecial,
					CuisineName = g.Cuisine.Name,
					City = g.City.Name,
					ChefsDishImagePath = g.ChefsSpecialImage
				})
				.FirstOrDefaultAsync();
			return model;
		}

		//Done
		public async Task<RestaurantDetailsViewModel> GetRestaurantDetailsAsync(Guid restaurnatId)
		{

			RestaurantDetailsViewModel? model = await this.restaurantRepository
				.GetAllAttached()
				.Include(p => p.UserRestaurants)
				.Where(p => p.Id == restaurnatId && p.IsDeleted == false)
				.Select(p => new RestaurantDetailsViewModel()
				{
					Id = p.Id.ToString(),
					Name = p.Name,
					Description = p.Description,
					MenuDescription = p.MenuDescription,
					AtmosphereDescription = p.AtmosphereDescription,
					ImageURL = p.ImageURL,
					ChefsDishName = p.ChefsSpecial,
					ChefsDishImage = p.ChefsSpecialImage,
					CuisineName = p.Cuisine.Name,
					Address = p.Address,
					Category = p.Category.Name,
					PriceRange = p.PricaRange,
					Likes = p.UserRestaurants.Where(r => r.RestaurantId == p.Id).Count(),
					City = p.City.Name,
					Publisher = p.Publisher.UserName ?? string.Empty,
					AllComment = p.RestaurantsComments
					.Where(rc => rc.IsDeleted == false)
					.Select(rc => new CommentAllViewModel()
					{
						Message = rc.Message,
						CreatedOn = rc.CreatedDate,
						UserId = rc.UserId.ToString(),
						Id = rc.Id.ToString(),
						UserName = rc.User.UserName ?? string.Empty,
						ProfilePicture = rc.User.ProfilePricturePath!
					})

				})
				.FirstOrDefaultAsync();

			return model;
		}

		public async Task<PaginatedList<RestaurantIndexViewModel>> IndexGetAllRestaurantsAsync(int? pageNumber, string sortOrder, string searchItem, string currentFilter)
		{
			int pageSize = 16;

			var restaurants = this.restaurantRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false)
				.Select(r => new RestaurantIndexViewModel()
				{
					Id = r.Id.ToString(),
					Name = r.Name,
					ImageURL = r.ImageURL,
					Publisher = r.Publisher.UserName!,
					Category = r.Category.Name,
					PriceRange = r.PricaRange,
					City = r.City.Name,
					Description = r.Description.Substring(0, 99)

				});


			switch (sortOrder)
			{

				case "name_desc":
					restaurants = restaurants.OrderByDescending(s => s.Name);
					break;
				default:
					restaurants = restaurants.OrderBy(r => r.Name);
					break;
			}

			if (!String.IsNullOrEmpty(searchItem))
			{
				restaurants = restaurants.Where(r => r.Name.ToLower().Contains(searchItem.ToLower()));
			}

			var restaurantList = await PaginatedList<RestaurantIndexViewModel>.CreateAsync(restaurants, pageNumber ?? 1, pageSize);

			return restaurantList;
		}

	}
}

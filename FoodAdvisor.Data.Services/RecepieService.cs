using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels;
using FoodAdvisor.ViewModels.CommentViewModel;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodAdvisor.Data.Services
{
	public class RecepieService : BaseService, IRecepieService
	{
		private readonly IRepository<Recepie, Guid> recepieRepository;
		private readonly IWebHostEnvironment enviorment;
		private IRepository<UserRecepie, object> userRecepieRepository;
		private readonly IFileService fileService;


		public RecepieService(IRepository<Recepie, Guid> recepieRepository, IWebHostEnvironment enviorment,
			IRepository<UserRecepie, object> userRecepieRepository, IFileService fileService)
		{
			this.recepieRepository = recepieRepository;
			this.enviorment = enviorment;
			this.userRecepieRepository = userRecepieRepository;
			this.fileService = fileService;
		}

		public async Task AddRecepiesAsync(AddRecepieViewModel model, Guid userId, IFormFile file)
		{
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			long maxSize = 5 * 1024 * 1024; // 5MB

			string fileName = $"{userId}_{model.Name}_{Path.GetFileName(file.FileName)}";

			string filePath = await fileService.UploadFileAsync(file, "RecepiePictures", fileName);

			Recepie recepie = new Recepie
			{
				Name = model.Name,
				Description = model.Description,
				CookingTime = model.CookingTime,
				PublisherId = userId,
				ImageURL = filePath,
				CreatedOn = DateTime.Now,
				RecepieCategoryId = model.CategoryId,
				Products = model.Products,
				NumberOfServing = model.Servings,
				RecepieDificultyId = model.DificultyId
			};

			await recepieRepository.AddAsync(recepie);
		}

		public async Task<DetailsRecepieViewModel> GetRecepietDetailsAsync(Guid recepieId)
		{
			DetailsRecepieViewModel? model = await this.recepieRepository
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
					Category = r.RecepieCategory.Name,
					Products = r.Products,
					PublisherFullName = $"{r.Publisher.FirstName} {r.Publisher.LastName}",
					PublisherPicture = r.Publisher.ProfilePricturePath,
					ImagePath = r.ImageURL,
					Dificulty = r.RecepieDificulty.DificultyName,
					Servings = r.NumberOfServing,
					AllComment = r.RecepieComments
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

				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task<DeleteRecepieViewModel> DeleteRecepieViewAsync(Guid recepieId)
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
				   CreatedOn = r.CreatedOn,
				   ImagePath = r.ImageURL
			   })
			   .FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> DeleteRecepieAsync(DeleteRecepieViewModel model)
		{
			Recepie? recepie = await this.recepieRepository
				.GetByIdAsync(Guid.Parse(model.Id));

			string filePath = enviorment.WebRootPath;
			string imageToDelete = $"{filePath}\\{recepie.ImageURL}";

			if (recepie != null)
			{
				fileService.DeleteFile(recepie.ImageURL);
				recepie.IsDeleted = true;
				await recepieRepository.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<AddRecepieViewModel> EditRecepieViewAsync(Guid id)
		{
			AddRecepieViewModel? model = await this.recepieRepository
				.GetAllAttached()
				.Where(r => r.Id == id)
				.Select(r => new AddRecepieViewModel()
				{
					ImagePath = r.ImageURL,
					Name = r.Name,
					Description = r.Description,
					CookingTime = r.CookingTime,
					Products = r.Products,
					CategoryId = r.RecepieCategoryId,
					Servings = r.NumberOfServing,
					DificultyId = r.RecepieDificultyId


				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> EditRecepieAsync(AddRecepieViewModel model, string recepieId, Guid userId, IFormFile file)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
			if (!isGuidValid)
			{
				return false;
			}

			Recepie? editedRecepie = await this.recepieRepository
			.GetByIdAsync(recepieGuid);
			if (editedRecepie == null)
			{
				return false;
			}

			editedRecepie.Name = model.Name;
			editedRecepie.Description = model.Description;
			editedRecepie.CookingTime = model.CookingTime;
			editedRecepie.Products = model.Products;
			editedRecepie.RecepieCategoryId = model.CategoryId;
			editedRecepie.RecepieDificultyId = model.DificultyId;
			editedRecepie.NumberOfServing = model.Servings;

			if (file != null)
			{
				fileService.DeleteFile(editedRecepie.ImageURL);

				string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
				long maxSize = 5 * 1024 * 1024;
				if (!fileService.IsFileValid(file, allowedExtensions, maxSize))
				{
					throw new ArgumentException("Unvalid file!");
				}

				string fileName = $"{userId}_{model.Name}_{Path.GetFileName(file.FileName)}";

				string newImagePath = await fileService.UploadFileAsync(file, "RecepiePictures", fileName);

				editedRecepie.ImageURL = newImagePath;
			}

			await this.recepieRepository.UpdateAsync(editedRecepie);
			return true;
		}

		public async  Task<PaginatedList<RecepieIndexViewModel>> IndexGetAllRecepiesAsync(int? pageNumber, string sortOrder, string searchItem, string currentFilter)
		{
			int pageSize = 16;

			var recepies = this.recepieRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false)
				.Select(r => new RecepieIndexViewModel()
				{
					Id = r.Id.ToString(),
					Name = r.Name,
					CookingTime = r.CookingTime,
					ImageURL = r.ImageURL,
					Publisher = r.Publisher.UserName!,
					Category = r.RecepieCategory.Name,
					AuthorPicturePath = r.Publisher.ProfilePricturePath!,
					Servings = r.NumberOfServing,
					CreatedOn = r.CreatedOn.ToString(),
					DificultyLevel = r.RecepieDificultyId.ToString(),
					Description = r.Description.Substring(0, 99)
				});

			switch (sortOrder)
			{
				case "Name":
					recepies = recepies.OrderBy(r => r.Name);
					break;
				case "name_desc":
					recepies = recepies.OrderByDescending(s => s.Name);
					break;
				case "Dificulty":
					recepies = recepies.OrderBy(r => r.DificultyLevel);
					break;
				case "dificulty_desc":
					recepies = recepies.OrderByDescending(s => s.DificultyLevel);
					break;

				case "date_desc":
					recepies = recepies.OrderByDescending(r => r.CreatedOn);
					break;

				default:
					recepies = recepies.OrderBy(r => r.CreatedOn);
					break;

			}
			if (!String.IsNullOrEmpty(searchItem))
			{
				recepies = recepies.Where(r => r.Name.ToLower().Contains(searchItem.ToLower()));
			}

			var recepielist = await PaginatedList<RecepieIndexViewModel>.CreateAsync(recepies, pageNumber ?? 1, pageSize);

			return  recepielist;
		}

	}
}

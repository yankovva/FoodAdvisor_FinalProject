using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.ViewModels;
using FoodAdvisor.ViewModels.CommentViewModel;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using static FoodAdvisor.Common.ApplicationConstants;
using static FoodAdvisor.Common.ErrorMessages;


namespace FoodAdvisor.Data.Services
{
	public class RecepieService : BaseService, IRecepieService
	{
		private readonly IRepository<Recepie, Guid> recepieRepository;
		private IRepository<UserRecepie, object> userRecepieRepository;
		private readonly IFileService fileService;


		public RecepieService(IRepository<Recepie, Guid> recepieRepository,
			IRepository<UserRecepie, object> userRecepieRepository, 
			IFileService fileService)
		{
			this.recepieRepository = recepieRepository;
			this.userRecepieRepository = userRecepieRepository;
			this.fileService = fileService;
		}

		public async Task AddRecepiesAsync(AddRecepieViewModel model, Guid userId, IFormFile file)
		{
			
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".jfif" };
			long maxSize = 5 * 1024 * 1024; // 5MB

			if (!fileService.IsFileValid(file, allowedExtensions, maxSize))
			{
				throw new ArgumentException(InvalidFileMessage);
			}

			string fileName = $"{userId}_{model.Name}_{Path.GetFileName(file.FileName)}";

			string filePath = await fileService.UploadFileAsync(file, RecepiePicturesFolderName, fileName);

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
				RecepieDificultyId = model.DificultyId,
				CookingSteps = model.CookingSteps
			};

			await recepieRepository.AddAsync(recepie);
		}

		public async Task<DetailsRecepieViewModel> GetRecepietDetailsAsync(string recepieId)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
			if (!isGuidValid)
			{
				throw new ArgumentException(InvalidGuidMessage);
			}

			DetailsRecepieViewModel? model = await this.recepieRepository
				.GetAllAttached()
				.Where(r => r.IsDeleted == false && r.Id == recepieGuid)
				.Select(r => new DetailsRecepieViewModel()
				{
					Id = recepieGuid,
					Name = r.Name,
					Description = r.Description,
					CookingSteps = r.CookingSteps,
					CreatetOn = r.CreatedOn,
					CookingTime = r.CookingTime,
					Publisher = r.Publisher.UserName!,
					Category = r.RecepieCategory.Name,
					Products = r.Products.Split(", ", StringSplitOptions.None).ToList(),
					PublisherFullName = $"{r.Publisher.FirstName} {r.Publisher.LastName}",
					PublisherPicture = r.Publisher.ProfilePricturePath,
					PublisherLocation = r.Publisher.Country,
					PublisherId = r.PublisherId.ToString(),
					PublisherQuote = r.Publisher.AboutMe ?? DefaultQuote,
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

		public async Task<DeleteRecepieViewModel> DeleteRecepieViewAsync(string recepieId)
		{
			Guid recepieGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(recepieId, ref recepieGuid);
			if (!isGuidValid)
			{
				throw new ArgumentException(InvalidGuidMessage);
			}

			DeleteRecepieViewModel? model = await this.recepieRepository
				.GetAllAttached()
			   .Where(r => r.Id == recepieGuid && r.IsDeleted == false)
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
					DificultyId = r.RecepieDificultyId,
					CookingSteps = r.CookingSteps

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
			editedRecepie.CookingSteps = model.CookingSteps;

			if (file == null)
			{
				return false;
			}
			if (editedRecepie.ImageURL != NoImage)
			{
				fileService.DeleteFile(editedRecepie.ImageURL);
			}

			string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".jfif" };
			long maxSize = 5 * 1024 * 1024;
			if (!fileService.IsFileValid(file, allowedExtensions, maxSize))
			{
				throw new ArgumentException(InvalidFileMessage);
			}

			string fileName = $"{userId}_{model.Name}_{Path.GetFileName(file.FileName)}";

			string newImagePath = await fileService.UploadFileAsync(file, RecepiePicturesFolderName, fileName);

			editedRecepie.ImageURL = newImagePath;
			await this.recepieRepository.UpdateAsync(editedRecepie);

			return true;

		}

		public async Task<IEnumerable<RecepieIndexViewModel>> IndexGetAllRecepiesAsync(FilterIndexRecipeViewModel model)
		{
			IQueryable<Recepie> allRecipes = this.recepieRepository
				.GetAllAttached();

			if (!String.IsNullOrWhiteSpace(model.SearchQuery))
			{
				allRecipes = allRecipes
					.Where(m => m.Name.ToLower().Contains(model.SearchQuery.ToLower()));
			}

			if (!String.IsNullOrWhiteSpace(model.CategoryFilter))
			{
				allRecipes = allRecipes
					.Where(m => m.RecepieCategory.Name.ToLower() == model.CategoryFilter.ToLower());
			}

			if (!String.IsNullOrWhiteSpace(model.DificultyFilter))
			{
				allRecipes = allRecipes
					.Where(m => m.RecepieDificulty.DificultyName.ToLower() == model.DificultyFilter.ToLower());
			}


			if (model.CurrentPage.HasValue &&
				model.EntitiesPerPage.HasValue)
			{
				allRecipes = allRecipes
					.Skip(model.EntitiesPerPage.Value * (model.CurrentPage.Value - 1))
					.Take(model.EntitiesPerPage.Value);

			}
			var recepies = await allRecipes.Select(r => new RecepieIndexViewModel()
			{
				Id = r.Id.ToString(),
				Name = r.Name,
				CookingTime = r.CookingTime,
				ImageURL = r.ImageURL,
				Publisher = r.Publisher.UserName ?? "unkown",
				Category = r.RecepieCategory.Name ?? "unknwon",
				AuthorPicturePath = r.Publisher.ProfilePricturePath ?? "no-picture",
				Servings = r.NumberOfServing,
				CreatedOn = r.CreatedOn.ToString(),
				DificultyLevel = r.RecepieDificultyId.ToString()  ?? "unknown",
				Description = r.Description.Substring(0, 99) ?? "unknown",
			}).ToArrayAsync();

			return recepies;
		}

			public async Task<IEnumerable<string>> GetAllCategoriesAsync()
			{
				IEnumerable<string> allCategories = await this.recepieRepository
					.GetAllAttached()
					.Select(c => c.RecepieCategory.Name)
					.Distinct()
					.ToArrayAsync();

				return allCategories;
			}

			public async Task<IEnumerable<string>> GetAllDificultiesAsync()
			{
				IEnumerable<string> allDificulties = await this.recepieRepository
					.GetAllAttached()
					.Select(c => c.RecepieDificulty.DificultyName)
					.Distinct()
					.ToArrayAsync();

				return allDificulties;
			}

		
		public async Task<int> GetFilteredRecepiesCountAsync(FilterIndexRecipeViewModel inputModel)
		{
			FilterIndexRecipeViewModel model = new FilterIndexRecipeViewModel()
			{
				CurrentPage = null,
				EntitiesPerPage = null,
				SearchQuery = inputModel.SearchQuery,
				CategoryFilter = inputModel.CategoryFilter,
				DificultyFilter = inputModel.DificultyFilter,
			};

			int recipesCount = (await this.IndexGetAllRecepiesAsync(model))
				.Count();

			return recipesCount;
		}

	}
}
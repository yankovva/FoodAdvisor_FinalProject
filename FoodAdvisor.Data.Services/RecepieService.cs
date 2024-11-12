using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
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

		public RecepieService(IRepository<Recepie, Guid> recepieRepository, IWebHostEnvironment enviorment)
		{
			this.recepieRepository = recepieRepository;
			this.enviorment = enviorment;
		}

		public async Task AddRecepiesAsync(AddRecepieViewModel model, Guid userId, IFormFile file)
		{
			string uploadFolder = Path.Combine(enviorment.WebRootPath, "RecepiePictures");

			if (!Directory.Exists(uploadFolder))
			{
				Directory.CreateDirectory(uploadFolder);
			}

			string fileName = Path.GetFileName(file.FileName);
			string fileSavePath = Path.Combine("RecepiePictures", fileName);

			using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, fileSavePath), FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			Recepie recepie = new Recepie()
			{
				Name = model.Name,
				Description = model.Description,
				CookingTime = model.CookingTime,
				PublisherId = userId,
				ImageURL = fileSavePath,
				CreatedOn = DateTime.Now,
				RecepieCategoryId = model.CategoryId,
				Products = model.Products
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
					Publisher = r.Publisher.UserName!,
					Category = r.RecepieCategory.Name
				})
				.ToArrayAsync();

			return recepies;
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
					ImagePath = r.ImageURL,
					AllComment = r.RecepieComments
					.Where(rc => rc.IsDeleted == false)
					.Select(rc => new CommentAllViewModel()
					{
						Message = rc.Message,
						CreatedOn = rc.CreatedDate,
						UserId = rc.UserId.ToString(),
						Id = rc.Id.ToString(),
						UserName = rc.User.UserName ?? string.Empty
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
				   CreatedOn = r.CreatedOn
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
				recepie.IsDeleted = true;
				await this.recepieRepository.SaveChangesAsync();
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
					CategoryId = r.RecepieCategoryId
				}).FirstOrDefaultAsync();

			return model;
		}

		public async Task<bool> EditRecepieAsync(AddRecepieViewModel model, string recepieId, Guid userId, IFormFile file)
		{
			string uploadFolder = Path.Combine(enviorment.WebRootPath, "RecepiePictures");

			if (!Directory.Exists(uploadFolder))
			{
				Directory.CreateDirectory(uploadFolder);
			}

			string fileName = Path.GetFileName(file.FileName);
			string fileSavePath = Path.Combine("RecepiePictures", fileName);

			using (FileStream stream = new FileStream(Path.Combine(enviorment.WebRootPath, fileSavePath), FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
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
			editedRecepie.ImageURL = fileSavePath;
			editedRecepie.Description = model.Description;
			editedRecepie.CookingTime = model.CookingTime;
			editedRecepie.Products = model.Products;
			editedRecepie.RecepieCategoryId = model.CategoryId;

			await this.recepieRepository.UpdateAsync(editedRecepie);
			return true;
		}


	}
}

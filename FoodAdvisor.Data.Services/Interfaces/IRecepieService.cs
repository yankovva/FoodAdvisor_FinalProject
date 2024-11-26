using FoodAdvisor.ViewModels;
using FoodAdvisor.ViewModels.RecepiesViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRecepieService 
	{

		Task<PaginatedList<RecepieIndexViewModel>> IndexGetAllRecepiesAsync(int? pageNumber, string sortOrder, string searchItem, string currentFilter);
		Task AddRecepiesAsync(AddRecepieViewModel model, Guid userId, IFormFile file);
		Task<DetailsRecepieViewModel> GetRecepietDetailsAsync(Guid recepieId);
		Task<DeleteRecepieViewModel> DeleteRecepieViewAsync(Guid recepieId);

		Task<bool> DeleteRecepieAsync(DeleteRecepieViewModel model);
		Task<AddRecepieViewModel> EditRecepieViewAsync(Guid id);
		Task<bool> EditRecepieAsync(AddRecepieViewModel model, string recepieId, Guid userId, IFormFile file);

    }
}

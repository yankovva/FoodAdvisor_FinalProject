﻿using FoodAdvisor.ViewModels.RecepiesViewModels;
using FoodAdvisor.ViewModels.RestaurantViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Services.Interfaces
{
	public interface IRecepieService 
	{
		Task<IEnumerable<RecepieIndexViewModel>> IndexGetAllRecepiesAsync();
		Task AddRecepiesAsync(AddRecepieViewModel model, Guid userId);
		Task<DetailsRecepieViewModel> GetRecepietDetailsAsync(Guid recepieId);
		Task<DeleteRecepieViewModel> DeleteRecepieViewAsync(Guid recepieId);

		Task<bool> DeleteRecepieAsync(DeleteRecepieViewModel model);
		Task<AddRecepieViewModel> EditRecepieViewAsync(Guid id);
		Task<bool> EditRecepieAsync(AddRecepieViewModel model, string recepieId, Guid userId);

    }
}

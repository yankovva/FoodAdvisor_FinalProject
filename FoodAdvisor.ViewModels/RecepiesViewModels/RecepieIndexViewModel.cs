using FoodAdvisor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
    public class RecepieIndexViewModel
    {
        public required string Id { get; set; } 
        public required string Name { get; set; } 
        public int CookingTime { get; set; }
        public  required string Publisher { get; set; }
        public string? ImageURL { get; set; }
        public required string Category { get; set; }
		public required string AuthorPicturePath { get; set; } 
        public int Servings { get; set; }
        public required string CreatedOn { get; set; }
        public required string DificultyLevel { get; set; }
        public required string Description { get; set; } 

	}
}

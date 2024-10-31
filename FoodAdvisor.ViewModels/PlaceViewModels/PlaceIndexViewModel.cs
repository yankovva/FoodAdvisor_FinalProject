using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.PlaceViewModels
{
    public class PlaceIndexViewModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; } 
        public string? ImageURL { get; set; }
        public required string Address { get; set; } 
        public required double Rating { get; set; }
        public required string Description { get; set; } 
        public required string Publisher { get; set; }
        public required string Category { get; set; }

    }
}

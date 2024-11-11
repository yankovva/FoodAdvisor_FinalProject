﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
    public class RecepieIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int CookingTime { get; set; }
        public string Publisher { get; set; } = null!;
        public string? ImageURL { get; set; }
        public string Category { get; set; } = null!;

	}
}
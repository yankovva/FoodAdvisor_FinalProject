using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.RecepiesViewModels
{
    public class RecepiePaginationIndexViewModel
    {
        [BindProperty]
        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }

        public IEnumerable<RecepieIndexViewModel> Recepies { get; set; } = new List<RecepieIndexViewModel>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.UserViewModels
{
    public class IndexAllUsersViewModel
    {
        public required string Id { get; set; } 
        public string? Email { get; set; }
        public string? Username { get; set; }
        public bool IsManager { get; set; }

        public IEnumerable<string> CurrentRoles { get; set; } = null!;

    }
}

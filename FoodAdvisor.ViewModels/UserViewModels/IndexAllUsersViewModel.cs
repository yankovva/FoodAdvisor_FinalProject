using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels.UserViewModels
{
    public class IndexAllUsersViewModel
    {
        public string Id { get; set; } = null!;

        public string? Email { get; set; }
        public string? Username { get; set; }

        public IEnumerable<string> CurrentRoles { get; set; } = null!;

    }
}

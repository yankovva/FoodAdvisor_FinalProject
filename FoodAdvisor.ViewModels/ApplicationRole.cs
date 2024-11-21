using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.ViewModels
{
    public class ApplicationRole: IdentityRole<Guid>
    {
        public ApplicationRole()
            :base()
        {
            
        }
        public ApplicationRole(string roleName)
            :base(roleName)
        {
            
        }
    }
}

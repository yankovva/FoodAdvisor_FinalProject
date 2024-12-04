using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Models
{
    [PrimaryKey(nameof(ApplicationUserId), nameof(RestaurantId))]
    public class UserRestaurant
    {
        [Comment("Identifier of the ApplicationUser")]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        [Comment("Identifier of the Restaurant")]
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}

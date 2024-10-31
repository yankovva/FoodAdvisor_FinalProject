using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Models
{
    [PrimaryKey(nameof(ApplicationUserId), nameof(PlaceId))]
    public class UserPlace
    {
        [Comment("Identifier of the ApplicationUser")]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        [Comment("Identifier of the Place")]
        public Guid PlaceId { get; set; }
        public Place Place { get; set; } = null!;
    }
}

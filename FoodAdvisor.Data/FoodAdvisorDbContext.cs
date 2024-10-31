using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor.Data
{
    public class FoodAdvisorDbContext : IdentityDbContext
    {
        public FoodAdvisorDbContext()
        {

        }

        public FoodAdvisorDbContext(DbContextOptions options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}

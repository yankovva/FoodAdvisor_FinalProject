using FoodAdvisor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodAdvisor.Data
{
    public class FoodAdvisorDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public FoodAdvisorDbContext()
        {

        }

        public FoodAdvisorDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<UserPlace> UsersPlaces { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
               .Entity<Category>()
               .HasData(
               new Category {  Name = "Restaurant" },
               new Category {  Name = "Cafe" },
               new Category {  Name = "Bar & Dinner" },
               new Category { Name = "Fast Food" },
               new Category {  Name = "Bakery" },
               new Category { Name = "Bistro" });

        }
    }
}

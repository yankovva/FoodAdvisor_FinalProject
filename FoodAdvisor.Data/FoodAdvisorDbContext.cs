using FoodAdvisor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ApplicationConstants;
using FoodAdvisor.ViewModels;


namespace FoodAdvisor.Data
{
	public class FoodAdvisorDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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
		public virtual DbSet<RestaurantCuisine> Cuisines { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<UserRestaurant> UsersRestaurants { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<Manager> Managers { get; set; }
		public virtual DbSet<Recepie> Recepies { get; set; }
		public virtual DbSet<UserRecepie> UsersRecepies { get; set; }
		public virtual DbSet<RecepieCategory> RecepiesCategories { get; set; }
		public virtual DbSet<RecepieDificulty> RecepiesDificulties { get; set; }







		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>()
				.Property(u => u.Createdon)
				.HasDefaultValue(DateTime.Now);

			builder.Entity<ApplicationUser>()
				.Property(u => u.ProfilePricturePath)
				.HasDefaultValue($"{NoImageAccount}");

			builder.Entity<Restaurant>()
				.Property(r => r.PricaRange)
				.HasDefaultValue("$");

		}
	}
}

﻿using FoodAdvisor.Data.Models;
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
		public virtual DbSet<RestaurantComment> RestaurantsComments { get; set; }
		public virtual DbSet<RecepieComment> RecepiesComments { get; set; }
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
				.HasDefaultValue(NoImageAccount);

			builder.Entity<Restaurant>()
				.Property(r => r.PricaRange)
				.HasDefaultValue("$");


			builder
			   .Entity<Category>()
			   .HasData(
			   new Category { Name = "Restaurant" },
			   new Category { Name = "Cafe" },
			   new Category { Name = "Bar & Dinner" },
			   new Category { Name = "Fast Food" },
			   new Category { Name = "Bakery" },
			   new Category { Name = "Bistro" });


			builder
			  .Entity<RecepieCategory>()
			  .HasData(
			  new RecepieCategory { Name = "Breakfast" },
			  new RecepieCategory { Name = "Lunch" },
			  new RecepieCategory { Name = "Dinner" },
			  new RecepieCategory { Name = "Dessert" },
			  new RecepieCategory { Name = "Snack" },
			  new RecepieCategory { Name = "Side dish" },
			  new RecepieCategory { Name = "Starter" });

			builder
			  .Entity<RecepieDificulty>()
			  .HasData(
			  new RecepieDificulty { Id = 1, DificultyName = "Easy" },
			  new RecepieDificulty { Id = 2, DificultyName = "Medium" },
			  new RecepieDificulty { Id = 3, DificultyName = "Hard" },
			  new RecepieDificulty { Id = 4, DificultyName = "Expert" });

			builder
			 .Entity<RestaurantCuisine>()
			 .HasData(
			 new RestaurantCuisine { Name = "Mediteranean" },
			 new RestaurantCuisine {Name = "Chinease" },
			 new RestaurantCuisine {Name = "Italian" },
			 new RestaurantCuisine { Name = "Bulgarian" },
			  new RestaurantCuisine {Name = "Mexican" },
			 new RestaurantCuisine { Name = "Only drinks" },
			 new RestaurantCuisine {Name = "Japanese" },
			 new RestaurantCuisine {Name = "French" });

		}
	}
}

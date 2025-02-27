﻿using FoodAdvisor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.ApplicationConstants;
using FoodAdvisor.ViewModels;
using System.Reflection.Emit;


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

			builder.Entity<RecepieDificulty>().HasData(
		   new RecepieDificulty { Id = 1, DificultyName = "Easy" },
		   new RecepieDificulty { Id = 2, DificultyName = "Medium" },
		   new RecepieDificulty { Id = 3, DificultyName = "Hard" },
		   new RecepieDificulty { Id = 4, DificultyName = "Expert" }
	   );

		}
	}
}

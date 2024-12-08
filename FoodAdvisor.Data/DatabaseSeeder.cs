using FoodAdvisor.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data;
public class DatabaseSeeder
{
	public static async Task SeedDatabase(IServiceProvider services)
	{
		await using FoodAdvisorDbContext context = services.GetRequiredService<FoodAdvisorDbContext>();

		var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "data.json");

		try
		{
			string json = await File.ReadAllTextAsync(jsonFilePath, Encoding.Unicode, CancellationToken.None);
			SeedData data = JsonConvert.DeserializeObject<SeedData>(json)!; // Десериализиране 

			if (!context.Categories.Any())
			{
				if (data.Categories != null)
				{
					foreach (var category in data.Categories)
					{
						context.Categories.Add(category);
					}
				}
			}
			if (!context.RecepiesCategories.Any())
			{
				if (data.RecipeCategories != null)
				{
					foreach (var recepieCategory in data.RecipeCategories)
					{
						context.RecepiesCategories.Add(recepieCategory);

					}
				}
			}

			if (!context.RecepiesDificulties.Any())
			{
				if (data.RecipeDificulties != null)
				{
					foreach (var difficulty in data.RecipeDificulties)
					{
						context.RecepiesDificulties.Add(difficulty);
					}
				}
			}
			if (!context.Cuisines.Any())
			{
				if (data.RestaurantCuisines != null)
				{
					foreach (var cuisine in data.RestaurantCuisines)
					{
						context.Cuisines.Add(cuisine);
					}
				}
			}
			if (!context.Cities.Any())
			{
				if (data.Cities != null)
				{
					foreach (var city in data.Cities)
					{
						context.Cities.Add(city);
					}
				}
			}
			if (!context.Managers.Any())
			{
				if (data.Managers != null)
				{
					foreach (var manager in data.Managers)
					{
						context.Managers.Add(manager);
					}
				}
			}
			if (!context.Restaurants.Any())
			{
				if (data.Restaurants != null)
				{
					foreach (var restaurant in data.Restaurants)
					{
						context.Restaurants.Add(restaurant);
					}
				}
			}
			if (!context.Recepies.Any())
			{
				if (data.Recipes != null)
				{
					foreach (var recepie in data.Recipes)
					{
						context.Recepies.Add(recepie);
					}
				}
			}
			if (!context.Comments.Any())
			{
				if (data.Comments != null)
				{
					foreach (var comment in data.Comments)
					{
						context.Comments.Add(comment);
					}
				}
			}

			context.SaveChanges();

		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

}


public class SeedData
{
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<RecepieCategory> RecipeCategories { get; set; } = new List<RecepieCategory>();
    public List<RecepieDificulty> RecipeDificulties { get; set; } = new List<RecepieDificulty>();
    public List<RestaurantCuisine> RestaurantCuisines { get; set; } = new List<RestaurantCuisine>();
	public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
	public List<Recepie> Recipes { get; set; } = new List<Recepie>();
	public List<Comment> Comments { get; set; } = new List<Comment>();
	public List<Manager> Managers { get; set; } = new List<Manager>();
	public List<City> Cities { get; set; } = new List<City>();
}


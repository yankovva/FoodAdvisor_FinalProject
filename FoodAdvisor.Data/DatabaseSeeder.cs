using FoodAdvisor.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data;
public class DatabaseSeeder
{

    public static void SeedDatabase(FoodAdvisorDbContext context)
    {
        var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "json", "data.json");
        var json = File.ReadAllText(jsonFilePath);

        var data = JsonConvert.DeserializeObject<SeedData>(json); // Десериализиране 

        if (!context.Categories.Any())
        {
            // Добавяне на категории
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
            // Добавяне на категории рецепти
            if (data.RecepieCategories != null)
            {
                foreach (var recepieCategory in data.RecepieCategories)
                {
                    context.RecepiesCategories.Add(recepieCategory);

                }
            }
        }

        if (!context.RecepiesDificulties.Any())
        {
            // Добавяне на трудности на рецепти
            if (data.RecepieDificulties != null)
            {
                foreach (var difficulty in data.RecepieDificulties)
                {
                    context.RecepiesDificulties.Add(difficulty);
                }
            }
        }
        if (!context.Cuisines.Any())
        {
            //Добавяне на типове кухня
            if (data.RestaurantCuisines != null)
            {
                foreach (var cuisine in data.RestaurantCuisines)
                {
                    context.Cuisines.Add(cuisine);
                }
            }
        }
        // Записване на промените в базата
        context.SaveChanges();
    }
}


public class SeedData
{
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<RecepieCategory> RecepieCategories { get; set; } = new List<RecepieCategory>();
    public List<RecepieDificulty> RecepieDificulties { get; set; } = new List<RecepieDificulty>();
    public List<RestaurantCuisine> RestaurantCuisines { get; set; } = new List<RestaurantCuisine>();
}


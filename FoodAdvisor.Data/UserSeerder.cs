﻿using FoodAdvisor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace FoodAdvisor.Data
{
	public class UserSeerder
	{
		public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, IServiceProvider services)
		{

			await using FoodAdvisorDbContext context = services.GetRequiredService<FoodAdvisorDbContext>();

			var users = new List<(string Email, string Password,string Username, string Id,string ProfilePicture)>
				{
					("jenny@gmail.com", "Jenny123!", "JenyFromTheBlock","7df25137-b39a-4a91-903b-303c0582e389", "ProfilePictures\\1.jpg" ),
					("victor@gmail.com", "Victor123!!", "Victor", "622d3321-2af5-4148-a4c4-dce20b49c686", "ProfilePictures\\2.jpg"),
					("velina@gmail.com", "Velina123!", "Velina", "b2c8567c-a0b5-49ac-9c11-12c760dc4cc4", "ProfilePictures\\3.jpg"),
					("alferd@gmail.com", "Alferd123!", "Alferd", "55a88aeb-5a0d-4dcd-9f8f-2010d3d2746c", "ProfilePictures\\4.jpg"),
					("andrea@gmail.com", "Andrea123!!", "AndreaVs", "4b9593f1-17bf-433d-b4e9-60d3c11d2d83", "ProfilePictures\\5.jpg"),
				};

			if (context.Users.Count() <= 1)
			{
				foreach (var (email, password, username, id, profilePicture) in users)
				{
					var user = await userManager.FindByEmailAsync(email);
					if (user == null)
					{
						user = new ApplicationUser
						{
							UserName = username,
							Email = email,
							EmailConfirmed = true,
							Id = Guid.Parse(id),
							ProfilePricturePath = profilePicture
						};

						var result = await userManager.CreateAsync(user, password);
					}
				}
			}
		}

	}
}

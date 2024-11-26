﻿using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository;
using FoodAdvisor.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
		public static void RegisterRepositories(this IServiceCollection services, Assembly modelsAssembly)
		{
			// to do: Re-write the implementation in such way that the user must create a single class for repositories
			Type[] typesToExclude = new Type[] { };
			
			Type[] modelTypes = modelsAssembly
				.GetTypes()
				.Where(t => !t.IsAbstract && !t.IsInterface &&
							!t.Name.ToLower().EndsWith("attribute"))
				.ToArray();

			foreach (Type type in modelTypes)
			{
				if (!typesToExclude.Contains(type))
				{
					Type repositoryInterface = typeof(IRepository<,>);
					Type repositoryInstanceType = typeof(BaseRepository<,>);
					PropertyInfo? idPropInfo = type
						.GetProperties()
						.Where(p => p.Name.ToLower() == "id")
						.SingleOrDefault();

					Type[] constructArgs = new Type[2];
					constructArgs[0] = type;

					if (idPropInfo == null)
					{
						constructArgs[1] = typeof(object);
					}
					else
					{
						constructArgs[1] = idPropInfo.PropertyType;
					}

					repositoryInterface = repositoryInterface.MakeGenericType(constructArgs);
					repositoryInstanceType = repositoryInstanceType.MakeGenericType(constructArgs);

					services.AddScoped(repositoryInterface, repositoryInstanceType);
				}
			}
		}

		public static void RegisterServices(this IServiceCollection services)
		{

		}
	}
}

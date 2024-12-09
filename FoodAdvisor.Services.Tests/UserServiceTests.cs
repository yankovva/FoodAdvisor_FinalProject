using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository.Interfaces;
using FoodAdvisor.Data.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Services.Tests
{
	[TestFixture]
	internal class UserServiceTests
	{
		private Mock<UserManager<ApplicationUser>> userManager;
		private Mock<RoleManager<IdentityRole<Guid>>> roleManager;
		private Mock<IManagerService> managerService;
		
		[SetUp]
		public void Setup()
		{
			this.userManager = new Mock<UserManager<ApplicationUser>>();
			this.roleManager = new Mock<RoleManager<IdentityRole<Guid>>>() ;
			this.managerService = new Mock<IManagerService>();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Infrastructure
{
    public static class ClaimsPrincipalExtension
    {
		public static string? GetUserId(this ClaimsPrincipal? userClaimsPrincipal)
		{
			return userClaimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;
		}
	}
}

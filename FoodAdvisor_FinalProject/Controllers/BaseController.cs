using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodAdvisor_FinalProject.Controllers
{
    public class BaseController : Controller
    {
        //A method that will check if the given ID is valid or not
        public bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
		public string? GetCurrentUserId()
		{
			return User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}

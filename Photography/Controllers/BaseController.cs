using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Photography.Controllers
{
    public class BaseController:Controller
    {
        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);

            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }

        protected string? GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}

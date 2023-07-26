using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessApp.Web.Controllers
{

    [Authorize]
    public class BaseController : Controller
    {
        public IActionResult SessionAction()
        {
            // Your action logic...

            // Update the session's "last activity" timestamp
            HttpContext.Session.SetString("LastActivity", DateTime.Now.ToString());

            return View();
        }
        protected string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return id;
        }
    }
}

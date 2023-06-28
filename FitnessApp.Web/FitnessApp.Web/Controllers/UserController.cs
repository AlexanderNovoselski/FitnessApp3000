using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }
    }
}

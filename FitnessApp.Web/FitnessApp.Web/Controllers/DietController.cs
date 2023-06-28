using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class DietController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

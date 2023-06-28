using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

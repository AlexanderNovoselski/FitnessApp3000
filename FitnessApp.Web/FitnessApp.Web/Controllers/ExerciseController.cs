using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class ExerciseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

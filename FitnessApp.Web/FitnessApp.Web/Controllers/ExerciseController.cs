using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class ExerciseController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

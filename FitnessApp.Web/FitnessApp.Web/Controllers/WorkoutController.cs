using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class WorkoutController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

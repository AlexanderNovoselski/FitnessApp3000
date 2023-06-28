using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class GoalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

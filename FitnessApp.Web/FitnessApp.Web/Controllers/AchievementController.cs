using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class AchievementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class AchievementController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

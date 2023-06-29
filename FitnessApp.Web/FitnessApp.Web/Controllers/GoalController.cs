using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class GoalController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

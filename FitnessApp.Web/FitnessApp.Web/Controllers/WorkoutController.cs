using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models;
using FitnessApp.Web.ViewModels.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			//if (!User.Identity.IsAuthenticated) TODO return to login  
			//{
			//	return RedirectToAction("Login", "Account", new { area = "Identity" });
			//}

			var model = await workoutService.GetAllAsync();
            return View("GetAll", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Remove(int Id)
        {
            await workoutService.Remove(Id);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int Id)
        {
            var diet = await workoutService.GetWorkoutEdit(Id);

            if (diet == null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return View("Edit", diet);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateWorkoutViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View("Edit", model);
            }

            await workoutService.Update(model);

            return RedirectToAction(nameof(GetAll));
        }

    }
}

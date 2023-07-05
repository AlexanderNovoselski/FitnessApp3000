using FitnessApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace FitnessApp.Web.Controllers
{
    public class ExerciseController : BaseController
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }


        public async Task<IActionResult> GetAll(int workoutId, int page = 1, int pageSize = 10)
        {
            var model = await exerciseService.GetAll(workoutId);

            var pagedModel = model.ToPagedList(page, pageSize);
            ViewBag.WorkoutId = workoutId;

            return View(nameof(GetAll), pagedModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddToWorkout(int id, int workoutId)
        {
          
            var exercise = await exerciseService.AddToWorkout(id, workoutId);

            return RedirectToAction("GetAll", new { workoutId = workoutId });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(int id)
        {
            await exerciseService.Remove(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}

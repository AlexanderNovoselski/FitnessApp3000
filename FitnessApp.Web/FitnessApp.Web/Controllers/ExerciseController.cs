using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Diet;
using FitnessApp.Web.ViewModels.Models.Exercise;
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

		[HttpGet]
		[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRemove(int workoutId)
        {
			var model = await exerciseService.GetAllRemove(workoutId);
            ViewBag.WorkoutId = workoutId;
            return View(nameof(GetAllRemove), model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveFromWorkout(int workoutId, int id)
        {
            await exerciseService.RemoveExerciseFromWorkout(workoutId, id);
            return RedirectToAction(nameof(GetAll), "Workout");
        }

        [HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddToWorkout(int id, int workoutId)
		{
			var exercise = await exerciseService.AddToWorkout(id, workoutId);

			// Redirect to the GetAll action with the workoutId parameter
			return RedirectToAction(nameof(GetAll), "Exercise", new { workoutId });
		}

		[HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(int id)
        {
            await exerciseService.Remove(id);

            return RedirectToAction(nameof(GetAll));
        }

		[HttpGet]
		[Authorize(Roles = "Admin")]
		
		public async Task<IActionResult> GetCreateModel()
		{
			var model = await exerciseService.GetAddModel();

			return View("Add", model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(AddExerciseViewModel model)

		{
			if (ModelState.IsValid == false)
			{
				return View("Add", model);
			}
			await exerciseService.CreateAsync(model);

			return RedirectToAction(nameof(GetAll));
		}
	}
}

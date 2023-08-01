using FitnessApp.Services;
using FitnessApp.Services.Contracts;
using FitnessApp.Web.ViewModels.Models.Goal;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class GoalController : BaseController
    {
        private readonly IGoalService goalService;

        public GoalController(IGoalService goalService)
        {
            this.goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string searchWords = null)
        {
            var model = await goalService.GetMyAsync(GetUserId(), searchWords);
            
            return View("All", model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchGoals(string searchWords)
        {
            var userId = GetUserId();
            var model = await goalService.GetMyAsync(userId, searchWords);

            return PartialView("_SearchGoals", model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveGoal(int Id)
        {
            try
            {
                await goalService.Remove(Id);
                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(GetAll));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id)
        {
            var goal = await goalService.GetGoalEdit(Id);

            if (goal == null)
            {
                return RedirectToAction(nameof(GetAll));
            }

            return View("Edit", goal);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateGoalViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View("Edit", model);
            }

            await goalService.Update(model);

            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> GetCreateModel()
        {
            var model = await goalService.GetAddModel();

            return View("Add", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddGoalViewModel model)

        {
            if (ModelState.IsValid == false)
            {
                return View("Add", model);
            }
            await goalService.CreateAsync(model, GetUserId());

            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]

        public async Task<IActionResult> Complete(int id)
        {
            await goalService.Completed(id);

            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> CompletedGoals()
        {
            var completedGoals = await goalService.GetCompletedGoals(GetUserId());
            return PartialView("_CompletedGoals", completedGoals);
        }
    }
}

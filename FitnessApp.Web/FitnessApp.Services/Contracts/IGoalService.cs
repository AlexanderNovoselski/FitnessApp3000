using FitnessApp.Web.ViewModels.Models.Goal;

namespace FitnessApp.Services.Contracts
{
	public interface IGoalService
	{
		public Task<IEnumerable<GoalsViewModel>> GetMyAsync(string userId, string searchWords = null);

		public Task Remove(int id);

		public Task<UpdateGoalViewModel> GetGoalEdit(int GoalId);

		public Task Update(UpdateGoalViewModel model);

		public Task CreateAsync(AddGoalViewModel model, string userId);

		public Task<AddGoalViewModel> GetAddModel();

		public Task Completed(int GoalId);

		public Task<IEnumerable<CompletedViewModel>> GetCompletedGoals(string userId);

	}
}

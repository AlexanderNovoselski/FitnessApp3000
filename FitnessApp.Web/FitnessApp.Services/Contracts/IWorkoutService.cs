using FitnessApp.Web.ViewModels.Models;

namespace FitnessApp.Services.Contracts
{
    public interface IWorkoutService
    {
        public Task<IEnumerable<WorkoutsResultModel>> GetAllAsync();

        public Task Remove(int id);

        public Task<UpdateWorkoutViewModel> GetWorkoutEdit(int WorkoutId);

        public Task Update(UpdateWorkoutViewModel model);
    }
}
using FitnessApp.Web.ViewModels.Models.Exercise;
using FitnessApp.Web.ViewModels.Models.Workout;

namespace FitnessApp.Services.Contracts
{
    public interface IExerciseService
    {
        public Task<IEnumerable<ExerciseViewModel>> GetAll(int workoutId);

        public Task Remove(int ExerciseId);

        public Task<ExerciseViewModel> AddToWorkout(int ExerciseId, int WorkoutId);

        public Task CreateAsync(ExerciseViewModel model);

        public Task<ExerciseViewModel> GetAddModel();
    }
}

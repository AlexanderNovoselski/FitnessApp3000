using FitnessApp.Web.ViewModels.Models.Workout;

namespace FitnessApp.Services.Contracts
{
    public interface IWorkoutService
    {
        public Task<IEnumerable<WorkoutsViewModel>> GetAllAsync();

        public Task Remove(int id);

        public Task<UpdateWorkoutViewModel> GetWorkoutEdit(int WorkoutId);

        public Task Update(UpdateWorkoutViewModel model);

		public Task CreateAsync(AddWorkoutViewModel model);

		public Task<AddWorkoutViewModel> GetAddModel();

        public Task<List<ExerciseWorkoutModel>> GetExerciseDetails(int WorkoutId);

        public Task RemoveExerciseFromWorkout(int workoutId, int exerciseId);

    }
}
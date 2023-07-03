namespace FitnessApp.Web.ViewModels.Models
{
	public class WorkoutsResultModel
    {
        public int WorkoutId { get; set; }

        public string Name { get; set; }

		public string ImageUrl { get; set; }

		public List<string> UserIds { get; set; }

        public List<ExerciseWorkoutModel> ExerciseWorkouts { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public double CaloriesBurned { get; set; }

    }
}

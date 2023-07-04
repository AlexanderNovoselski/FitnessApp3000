using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Workout
{
    public class UpdateWorkoutViewModel
    {
        public int WorkoutId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<ExerciseWorkoutModel> ExerciseWorkouts { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(1, 120)]
        public int Duration { get; set; }

        [Required]
        [Range(1, 1000)]
        public double CaloriesBurned { get; set; }
    }
}

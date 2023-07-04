using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Workout
{
    public class ExerciseWorkoutModel
    {
        public int ExerciseId { get; set; }

        [Required]
        public string ExerciseName { get; set; }

        [Required]
        public string ExerciseDescription { get; set; }

        [Required]
        [Range(1, 10)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 30)]
        public int Reps { get; set; }
    }
}

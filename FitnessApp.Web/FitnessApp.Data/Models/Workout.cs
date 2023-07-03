using FitnessApp.DataLayer.Models;
using System.ComponentModel.DataAnnotations;

public class Workout
{
    [Key]
    public int WorkoutId { get; set; }

    [Required]
    public string Name { get; set; }

	[Required]
	public string ImageUrl { get; set; }

	public string Description { get; set; }

    public int Duration { get; set; }

    public double CaloriesBurned { get; set; }

    public List<ExerciseWorkout> ExerciseWorkouts { get; set; }

    public List<UserWorkout> UserWorkouts { get; set; }
}
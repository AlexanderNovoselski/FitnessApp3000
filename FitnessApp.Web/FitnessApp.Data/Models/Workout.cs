using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FitnessApp.DataLayer.Models;

public class Workout
{
    [Key]
    public int WorkoutId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public int Duration { get; set; }

    public double CaloriesBurned { get; set; }

    public List<ExerciseWorkout> ExerciseWorkouts { get; set; }

    public List<UserWorkout> UserWorkouts { get; set; }
}
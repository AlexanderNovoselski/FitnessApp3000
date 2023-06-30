using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ExerciseWorkout
{
	[Key]
	public int ExerciseWorkoutId { get; set; }

	[Required]
	public int ExerciseId { get; set; }

	[ForeignKey("ExerciseId")]
	public Exercise Exercise { get; set; }

	[Required]
	public int WorkoutId { get; set; }

	[ForeignKey("WorkoutId")]
	public Workout Workout { get; set; }
}
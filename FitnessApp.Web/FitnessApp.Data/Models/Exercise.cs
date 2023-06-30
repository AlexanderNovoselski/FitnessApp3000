using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Exercise
{
	[Key]
	public int ExerciseId { get; set; }

	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	public List<ExerciseWorkout> ExerciseWorkouts { get; set; }
}
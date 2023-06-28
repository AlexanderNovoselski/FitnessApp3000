using System.ComponentModel.DataAnnotations;

public class Exercise
{
	[Key]
	public int ExerciseId { get; set; }

	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	public List<Workout> Workouts { get; set; }
}
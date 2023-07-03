using System.ComponentModel.DataAnnotations;

public class Exercise
{
	[Key]
	public int ExerciseId { get; set; }

	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	[Required]
    public int Sets { get; set; }

	[Required]
    public int Reps { get; set; }

    public List<ExerciseWorkout> ExerciseWorkouts { get; set; }
}
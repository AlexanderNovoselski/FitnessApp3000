using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Workout
{
	[Key]
	public int WorkoutId { get; set; }

	[Required]
	public string UserId { get; set; }

	[ForeignKey("UserId")]
	public User User { get; set; }

	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	public int Duration { get; set; }

	public double CaloriesBurned { get; set; }

	public List<Exercise> Exercises { get; set; }
}
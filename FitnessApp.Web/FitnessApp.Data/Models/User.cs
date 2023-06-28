using FitnessApp.Enums;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
	public int Age { get; set; }

	public GenderType Gender { get; set; }

	public int Height { get; set; }

	public double Weight { get; set; }

	public List<Workout> Workouts { get; set; }

	public List<Goal> Goals { get; set; }

	public List<Diet> Diets { get; set; }

	public List<Achievement> Achievements { get; set; }
}
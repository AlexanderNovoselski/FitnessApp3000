﻿using FitnessApp.Enums;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
	public int Age { get; set; }

	public GenderType Gender { get; set; }

	public int HeightInMeters { get; set; }
	public int HeightInCentimeters { get; set; }

	public double Weight { get; set; }

	public List<ExerciseWorkout> ExerciseWorkouts { get; set; }

	public List<Goal> Goals { get; set; }

	public List<UserDiet> UserDiets { get; set; }

	public List<Achievement> Achievements { get; set; }
}
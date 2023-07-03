﻿using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models
{
	public class AddWorkoutViewModel
	{
		[Required]
		[MaxLength(60)]
		public string Name { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		[Required]
		[MaxLength(100)]
		public string Description { get; set; }

		[Required]
		[Range(0,180)]
		public int Duration { get; set; }

		[Required]
		[Range(0,1000)]
		public double CaloriesBurned { get; set; }

	}
}

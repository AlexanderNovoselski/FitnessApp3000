﻿using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Workout
{
    public class AddWorkoutViewModel
    {
        [Required]
		[StringLength(60, MinimumLength = 3)]
		public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
		[StringLength(250, MinimumLength = 5)]
		public string Description { get; set; }

        [Required]
        [Range(1, 180)]
        public int Duration { get; set; }

        [Required]
        [Range(1, 1000)]
        public double CaloriesBurned { get; set; }

    }
}

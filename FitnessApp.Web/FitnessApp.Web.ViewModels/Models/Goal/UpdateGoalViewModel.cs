﻿using FitnessApp.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Goal
{
	public class UpdateGoalViewModel
	{
		public int GoalId { get; set; }

		[Required]
		public GoalType GoalType { get; set; }

		[Required]
		[StringLength(250, MinimumLength = 5)]
		public string Description { get; set; }

		[Required]
		[Range(25, 350)]
		public int TargetWeight { get; set; }

		[Required]
		public DateTime TargetDate { get; set; }
	}
}

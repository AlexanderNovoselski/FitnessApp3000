using FitnessApp.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Goal
{
	public class AddGoalViewModel
	{
		[Required]
		public GoalType GoalType { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 5)]
		public string Description { get; set; }

		[Required]
		[Range(25,350)]
		public int TargetWeight { get; set; }

		[Required]
        [FutureDate]
        public DateTime TargetDate { get; set; }
	}
}

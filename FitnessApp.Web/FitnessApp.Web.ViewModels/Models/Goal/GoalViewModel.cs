﻿using FitnessApp.DataLayer.Enums;

namespace FitnessApp.Web.ViewModels.Models.Goal
{
	public class GoalsViewModel
	{
		public int GoalId { get; set; }

		public GoalType GoalType { get; set; }

		public string Description { get; set; }

		public int TargetWeight { get; set; }

		public bool isCompleted { get; set; } = false;

		public DateTime TargetDate { get; set; }

        public int RemainingDaysToTarget
        {
            get
            {
                if (TargetDate < DateTime.Now)
                    return 0;
                return (int)(TargetDate - DateTime.Now).TotalDays;
            }
        }
    }
}

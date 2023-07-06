using FitnessApp.DataLayer.Enums;

namespace FitnessApp.Web.ViewModels.Models.Goal
{
    public class CompletedViewModel
    {
        public int GoalId { get; set; }

        public GoalType GoalType { get; set; }

        public string Description { get; set; }

        public int TargetWeight { get; set; }

        public bool isCompleted { get; set; } = false;

        public DateTime TargetDate { get; set; }

        public DateTime CompletedDate { get; set; }
    }
}

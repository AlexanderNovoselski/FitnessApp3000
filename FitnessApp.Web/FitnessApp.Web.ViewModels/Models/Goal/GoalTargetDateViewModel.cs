using FitnessApp.DataLayer.Enums;

namespace FitnessApp.Web.ViewModels.Models.Goal
{
    public class GoalTargetDateViewModel
    {
        public int GoalId { get; set; }

        public GoalType GoalType { get; set; }
        public DateTime TargetDate { get; set; }
        public bool isCompleted { get; set; }
    }
}

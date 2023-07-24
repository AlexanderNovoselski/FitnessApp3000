namespace FitnessApp.Web.ViewModels.Models.Goal
{
    public class GoalTargetDate
    {
        public DateTime TargetDate { get; set; }
        public TimeSpan TimeRemaining { get; set; }

        public static TimeSpan GetTimeRemaining(DateTime targetDate)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan timeRemaining = targetDate - currentDate;

            if (timeRemaining >= TimeSpan.Zero && timeRemaining <= TimeSpan.FromDays(3))
            {
                return timeRemaining;
            }

            return TimeSpan.Zero;
        }

        public static GoalTargetDate GetDaysBeforeTargetDate(DateTime targetDate)
        {
            var goalTargetDate = new GoalTargetDate
            {
                TargetDate = targetDate,
                TimeRemaining = GetTimeRemaining(targetDate)
            };

            return goalTargetDate;
        }
    }
}

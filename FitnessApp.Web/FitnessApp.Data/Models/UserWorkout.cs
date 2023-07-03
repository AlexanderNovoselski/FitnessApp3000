namespace FitnessApp.DataLayer.Models
{
    public class UserWorkout
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int WorkoutId { get; set; }

        public Workout Workout { get; set; }
    }
}

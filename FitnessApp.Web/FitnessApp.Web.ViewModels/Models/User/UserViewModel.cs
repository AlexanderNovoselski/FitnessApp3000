using FitnessApp.Enums;

namespace FitnessApp.Web.ViewModels.Models.User
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ConfirmPassword { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }
    }
}

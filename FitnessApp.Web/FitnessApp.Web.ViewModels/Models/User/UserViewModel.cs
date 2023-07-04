using FitnessApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.User
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public string Height { get; set; }

        public double Weight { get; set; }
    }
}

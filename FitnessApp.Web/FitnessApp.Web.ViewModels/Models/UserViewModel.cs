using FitnessApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public int Height { get; set; }

        public double Weight { get; set; }
    }
}

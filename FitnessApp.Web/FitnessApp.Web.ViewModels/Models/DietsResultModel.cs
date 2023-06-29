using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Web.ViewModels.Models
{
    public class DietsResultModel
    {
        public int DietId { get; set; }

        public string UserId { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CaloriesIntake { get; set; }
    }
}

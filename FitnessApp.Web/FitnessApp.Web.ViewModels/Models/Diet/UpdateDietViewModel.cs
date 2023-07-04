using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Diet
{
    public class UpdateDietViewModel
    {
        public int DietId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 6000)]
        public int CaloriesIntake { get; set; }

    }
}

using FitnessApp.Web.ViewModels.Models.Enums;

namespace FitnessApp.Web.ViewModels.Models
{
    public class DietsResultModel
    {
        public int DietId { get; set; }

		public List<string> UserIds { get; set; }

		public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SortType SortingType { get; set; }

        public int CaloriesIntake { get; set; }

	}
}

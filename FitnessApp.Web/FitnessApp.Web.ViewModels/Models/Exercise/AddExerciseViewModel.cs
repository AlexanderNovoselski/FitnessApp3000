using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.ViewModels.Models.Exercise
{
	public class AddExerciseViewModel
	{

		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }

		[StringLength(250, MinimumLength = 3)]
		public string Description { get; set; }

		[Required]
		[Range(1,10)]
		public int Sets { get; set; }

		[Required]
		[Range(1, 25)]
		public int Reps { get; set; }

	}
}

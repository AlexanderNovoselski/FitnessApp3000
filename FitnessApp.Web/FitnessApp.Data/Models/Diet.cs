using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Diet
{
	[Key]
	public int DietId { get; set; }

	[Required]
	public string Name { get; set; }

    [Required]
    public string ImageUrl { get; set; }

	[Required]
	public string Description { get; set; }

	[Required]
	public int CaloriesIntake { get; set; }

	public List<UserDiet> UserDiets { get; set; }
}
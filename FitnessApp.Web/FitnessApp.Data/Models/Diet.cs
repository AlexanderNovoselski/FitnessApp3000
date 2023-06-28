using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Diet
{
	[Key]
	public int DietId { get; set; }

	[Required]
	public string UserId { get; set; }

	[ForeignKey("UserId")]
	public User User { get; set; }

	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	public int CaloriesIntake { get; set; }
}
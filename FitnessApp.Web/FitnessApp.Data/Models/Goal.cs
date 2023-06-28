using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Goal
{
	[Key]
	public int GoalId { get; set; }

	[Required]
	public string UserId { get; set; }

	[ForeignKey("UserId")]
	public User User { get; set; }

	public string Description { get; set; }

	public int TargetWeight { get; set; }

	public DateTime TargetDate { get; set; }
}
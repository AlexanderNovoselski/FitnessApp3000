using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FitnessApp.DataLayer.Enums;

public class Goal
{
	[Key]
	public int GoalId { get; set; }

	[Required]
	public string UserId { get; set; }

	[ForeignKey("UserId")]
	public User User { get; set; }

	public string Description { get; set; }

	public GoalType GoalType { get; set; }

	public int TargetWeight { get; set; }

	public bool isCompleted { get; set; } = false;

	public DateTime TargetDate { get; set; }

	public DateTime CompletedDate { get; set; }
}
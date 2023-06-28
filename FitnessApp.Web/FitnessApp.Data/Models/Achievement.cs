using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Achievement
{
	[Key]
	public int AchievementId { get; set; }

	[Required]
	public string UserId { get; set; }

	[ForeignKey("UserId")]
	public User User { get; set; }

	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	public DateTime DateEarned { get; set; }
}
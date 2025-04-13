using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(UserId), nameof(StepId))]
[Table("progresses")]
public class Progress
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("step_id")]
    public int StepId { get; set; }

    [Column("is_passed")]
    public bool IsPassed { get; set; }

    [Column("score")]
    public int Score { get; set; }


    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("StepId")]
    public Step Step { get; set; }
}
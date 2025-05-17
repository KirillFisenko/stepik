public class Progress
{
    public int UserId { get; set; }
    public int StepId { get; set; }
    public bool IsPassed { get; set; }
    public int Score { get; set; }

    public User User { get; set; }
    public Step Step { get; set; }
}

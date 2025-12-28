public class User
{
    public string FullName { get; set; } = default!;
    public string? Details { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.Now;
    public string? Avatar { get; set; }
    public bool IsActive { get; set; } = true;
    public int Knowledge { get; set; }
    public int Reputation { get; set; }
    public int FollowersCount { get; set; }
}
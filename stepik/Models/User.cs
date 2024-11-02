public class User
{
    public string FullName { get; set; }
    public string? Details { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.Now;
    public string? Avatar { get; set; }
    public bool IsActive { get; set; } = true;
}
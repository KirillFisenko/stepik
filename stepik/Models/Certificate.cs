public class Certificate
{
    public int UserId { get; set; }
    public int CourseId { get; set; }
    public int Grade { get; set; }
    public DateTime IssueDate { get; set; }
    public string Url { get; set; }

    public User User { get; set; }
    public Course Course { get; set; }
}

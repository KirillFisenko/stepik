public class CourseReview
{
    public int CourseId { get; set; }
    public int UserId { get; set; }
    public int? CommentId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Text { get; set; }
    public int Score { get; set; }
    public int EpicCount { get; set; }
    public int AbuseCount { get; set; }

    public Course Course { get; set; }
    public User User { get; set; }
    public Comment Comment { get; set; }
}

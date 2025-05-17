public class Comment
{
    public int Id { get; set; }
    public int? StepId { get; set; }
    public int? ReplyCommentId { get; set; }
    public int UserId { get; set; }
    public DateTime Time { get; set; }
    public string Text { get; set; }
    public int EpicCount { get; set; }
    public int AbuseCount { get; set; }

    public Step Step { get; set; }
    public Comment ReplyComment { get; set; }
    public List<Comment> ReplyComments { get; set; }
    public User User { get; set; }
    public CourseReview CourseReview { get; set; }
}

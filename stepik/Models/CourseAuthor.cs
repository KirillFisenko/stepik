public class CourseAuthor
{
    public int CourseId { get; set; }
    public int UserId { get; set; }

    public Course Course { get; set; }
    public User User { get; set; }
}

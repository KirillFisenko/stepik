public class Step
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int Position { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Cost { get; set; }

    public Lesson Lesson { get; set; }
    public List<Progress> Progresses { get; set; }
    public List<Comment> Comments { get; set; }
}

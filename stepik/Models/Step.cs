using System.ComponentModel.DataAnnotations.Schema;

[Table("steps")]
public class Step
{
    [Column("id")]
    public int Id { get; set; }

    [Column("lesson_id")]
    public int LessonId { get; set; }

    [Column("position")]
    public int Position { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [Column("cost")]
    public int Cost { get; set; }

    public Lesson Lesson { get; set; }
    public List<Progress> Progresses { get; set; }
    public List<Comment> Comments { get; set; }
}
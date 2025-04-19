using System.ComponentModel.DataAnnotations.Schema;

[Table("lessons")]
public class Lesson
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("epic_count")]
    public int EpicCount { get; set; }

    [Column("abuse_count")]
    public int AbuseCount { get; set; }


    public List<UnitLesson> UnitLessons { get; set; }
    public List<Step> Steps { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

[Table("units")]
public class Unit
{
    [Column("id")]
    public int Id { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    public Course Course { get; set; }
    public List<UnitLesson> UnitLessons { get; set; }
}
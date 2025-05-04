using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(UserId), nameof(CourseId))]
[Table("certificates")]
public class Certificate
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("grade")]
    public int Grade { get; set; }

    [Column("issue_date")]
    public DateTime IssueDate { get; set; }

    [Column("url")]
    public string Url { get; set; }

    public User User { get; set; }
    public Course Course { get; set; }
}
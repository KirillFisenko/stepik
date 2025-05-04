using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(UserId), nameof(CourseId))]
[Table("user_courses")]
public class UserCourse
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("is_favorite")]
    public bool IsFavorite { get; set; }

    [Column("is_pinned")]
    public bool IsPinned { get; set; }

    [Column("is_archived")]
    public bool IsArchived { get; set; }

    [Column("last_viewed")]
    public DateTime LastViewed { get; set; }

    public User User { get; set; }
    public Course Course { get; set; }
}
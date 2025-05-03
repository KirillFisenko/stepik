using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User
{
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(50)]
    public string FullName { get; set; }

    [Column("details")]
    [StringLength(50)]
    public string? Details { get; set; }

    [Column("join_date")]
    public DateTime JoinDate { get; set; }

    [Column("avatar")]
    public string? Avatar { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("knowledge")]
    public int Knowledge { get; set; }

    [Column("reputation")]
    public int Reputation { get; set; }

    [Column("followers_count")]
    public int FollowersCount { get; set; }

    [Column("days_without_break")]
    public int DaysWithoutBreak { get; set; }

    [Column("days_without_break_max")]
    public int DaysWithoutBreakMax { get; set; }

    [Column("solved_tasks")]
    public int SolvedTasks { get; set; }


    public List<UserCourse> UserCourses { get; set; }
    public List<CourseAuthor> CourseAuthors { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<UserSocialProvider> UserSocialProviders { get; set; }
    public List<Progress> Progresses { get; set; }
    public List<Comment> Comments { get; set; }
    public List<CourseReview> CourseReviews { get; set; }
}
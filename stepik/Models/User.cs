public class User
{
    public int id { get; set; }
    public string full_name { get; set; } = default!;
    public string? details { get; set; }
    public DateTime join_date { get; set; } = DateTime.Now;
    public string? avatar { get; set; }
    public bool is_active { get; set; } = true;
    public int knowledge { get; set; }
    public int reputation { get; set; }
    public int followers_count { get; set; }
    public int days_without_break { get; set; }
    public int days_without_break_max { get; set; }
    public int solved_tasks { get; set; }

    //public ICollection<UserCourse> UserCourses { get; set; }
    //public ICollection<CourseAuthor> CourseAuthors { get; set; }
    //public ICollection<Certificate> Certificates { get; set; }
    //public ICollection<UserSocialProvider> UserSocialProviders { get; set; }
    //public ICollection<Progress> Progresses { get; set; }
    //public ICollection<Comment> Comments { get; set; }
    //public ICollection<CourseReview> CourseReviews { get; set; }
}
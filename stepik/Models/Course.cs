public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Summary { get; set; }
    public string Photo { get; set; }
    public decimal Price { get; set; }

    public CertificateSetting CertificateSetting { get; set; }
    public List<UserCourse> UserCourses { get; set; }
    public List<CourseAuthor> CourseAuthors { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<Unit> Units { get; set; }
    public List<CourseReview> CourseReviews { get; set; }
}

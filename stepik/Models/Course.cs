using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("courses")]
public class Course
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(50)]
    public string Title { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }

    [Column("photo")]
    public string? Photo { get; set; }

    [Column("price")]
    public decimal Price { get; set; }


    public CertificateSetting CertificateSetting { get; set; }
    public List<UserCourse> UserCourses { get; set; }
    public List<CourseAuthor> CourseAuthors { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<Unit> Units { get; set; }
    public List<CourseReview> CourseReviews { get; set; }
}
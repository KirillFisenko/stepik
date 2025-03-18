using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    //public DbSet<Course> Courses { get; set; }
    //public DbSet<UserCourse> UserCourses { get; set; }
    //public DbSet<CourseAuthor> CourseAuthors { get; set; }
    //public DbSet<Certificate> Certificates { get; set; }
    //public DbSet<SocialProvider> SocialProviders { get; set; }
    //public DbSet<UserSocialProvider> UserSocialProviders { get; set; }
    //public DbSet<CertificateSetting> CertificateSettings { get; set; }
    //public DbSet<Unit> Units { get; set; }
    //public DbSet<Lesson> Lessons { get; set; }
    //public DbSet<UnitLesson> UnitLessons { get; set; }
    //public DbSet<Step> Steps { get; set; }
    //public DbSet<Progress> Progresses { get; set; }
    //public DbSet<Comment> Comments { get; set; }
    //public DbSet<CourseReview> CourseReviews { get; set; }

    public ApplicationDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.ApplyConfiguration(new CourseConfiguration());
        //modelBuilder.ApplyConfiguration(new UserCourseConfiguration());
        //modelBuilder.ApplyConfiguration(new CourseAuthorConfiguration());
        //modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        //modelBuilder.ApplyConfiguration(new SocialProviderConfiguration());
        //modelBuilder.ApplyConfiguration(new UserSocialProviderConfiguration());
        //modelBuilder.ApplyConfiguration(new CertificateSettingConfiguration());
        //modelBuilder.ApplyConfiguration(new UnitConfiguration());
        //modelBuilder.ApplyConfiguration(new LessonConfiguration());
        //modelBuilder.ApplyConfiguration(new UnitLessonConfiguration());
        //modelBuilder.ApplyConfiguration(new StepConfiguration());
        //modelBuilder.ApplyConfiguration(new ProgressConfiguration());
        //modelBuilder.ApplyConfiguration(new CommentConfiguration());
        //modelBuilder.ApplyConfiguration(new CourseReviewConfiguration());
    }
}
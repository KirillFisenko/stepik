using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
{
    public void Configure(EntityTypeBuilder<UserCourse> builder)
    {
        builder.ToTable("user_courses");

        builder.HasKey(uc => new { uc.UserId, uc.CourseId });

        builder.Property(uc => uc.UserId)
            .HasColumnName("user_id");

        builder.Property(uc => uc.CourseId)
            .HasColumnName("course_id");

        builder.Property(uc => uc.IsFavorite)
            .HasColumnName("is_favorite");

        builder.Property(uc => uc.IsPinned)
            .HasColumnName("is_pinned");

        builder.Property(uc => uc.IsArchived)
            .HasColumnName("is_archived");

        builder.Property(uc => uc.LastViewed)
            .HasColumnName("last_viewed");

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.UserCourses)
            .HasForeignKey(uc => uc.UserId);

        builder.HasOne(uc => uc.Course)
            .WithMany(c => c.UserCourses)
            .HasForeignKey(uc => uc.CourseId);
    }
}

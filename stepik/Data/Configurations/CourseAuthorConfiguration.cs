using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseAuthorConfiguration : IEntityTypeConfiguration<CourseAuthor>
{
    public void Configure(EntityTypeBuilder<CourseAuthor> builder)
    {
        builder.ToTable("courses_authors");

        builder.HasKey(ca => new { ca.CourseId, ca.UserId });

        builder.Property(ca => ca.CourseId)
            .HasColumnName("course_id");

        builder.Property(ca => ca.UserId)
            .HasColumnName("user_id");

        builder.HasOne(ca => ca.Course)
            .WithMany(c => c.CourseAuthors)
            .HasForeignKey(ca => ca.CourseId);

        builder.HasOne(ca => ca.User)
            .WithMany(u => u.CourseAuthors)
            .HasForeignKey(ca => ca.UserId);
    }
}

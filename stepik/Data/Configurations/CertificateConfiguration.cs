using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.ToTable("certificates");

        builder.HasKey(c => new { c.UserId, c.CourseId });

        builder.Property(c => c.UserId)
            .HasColumnName("user_id");

        builder.Property(c => c.CourseId)
            .HasColumnName("course_id");

        builder.Property(c => c.Grade)
            .HasColumnName("grade");

        builder.Property(c => c.IssueDate)
            .HasColumnName("issue_date");

        builder.Property(c => c.Url)
            .HasColumnName("url");

        builder.HasOne(c => c.User)
            .WithMany(u => u.Certificates)
            .HasForeignKey(c => c.UserId);

        builder.HasOne(c => c.Course)
            .WithMany(c => c.Certificates)
            .HasForeignKey(c => c.CourseId);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseReviewConfiguration : IEntityTypeConfiguration<CourseReview>
{
    public void Configure(EntityTypeBuilder<CourseReview> builder)
    {
        builder.ToTable("course_reviews");

        builder.HasKey(cr => new { cr.CourseId, cr.UserId });

        builder.Property(cr => cr.CourseId)
            .HasColumnName("course_id");

        builder.Property(cr => cr.UserId)
            .HasColumnName("user_id");

        builder.Property(cr => cr.CommentId)
            .HasColumnName("comment_id");

        builder.Property(cr => cr.CreatedDate)
            .HasColumnName("created_date");

        builder.Property(cr => cr.Text)
            .HasColumnName("text");

        builder.Property(cr => cr.Score)
            .HasColumnName("score");

        builder.Property(cr => cr.EpicCount)
            .HasColumnName("epic_count");

        builder.Property(cr => cr.AbuseCount)
            .HasColumnName("abuse_count");

        builder.HasOne(cr => cr.Course)
            .WithMany(c => c.CourseReviews)
            .HasForeignKey(cr => cr.CourseId);

        builder.HasOne(cr => cr.User)
            .WithMany(u => u.CourseReviews)
            .HasForeignKey(cr => cr.UserId);

        builder.HasOne(cr => cr.Comment)
            .WithOne(c => c.CourseReview)
            .HasForeignKey<CourseReview>(cr => cr.CommentId);
    }
}

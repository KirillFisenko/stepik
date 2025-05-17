using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.StepId)
            .HasColumnName("step_id");

        builder.Property(c => c.ReplyCommentId)
            .HasColumnName("reply_comment_id");

        builder.Property(c => c.UserId)
            .HasColumnName("user_id");

        builder.Property(c => c.Time)
            .HasColumnName("time");

        builder.Property(c => c.Text)
            .HasColumnName("text");

        builder.Property(c => c.EpicCount)
            .HasColumnName("epic_count");

        builder.Property(c => c.AbuseCount)
            .HasColumnName("abuse_count");

        builder.HasOne(c => c.Step)
            .WithMany(s => s.Comments)
            .HasForeignKey(c => c.StepId);

        builder.HasOne(c => c.ReplyComment)
            .WithMany(c => c.ReplyComments)
            .HasForeignKey(c => c.ReplyCommentId);

        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);
    }
}

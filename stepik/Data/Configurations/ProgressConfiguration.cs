using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
{
    public void Configure(EntityTypeBuilder<Progress> builder)
    {
        builder.ToTable("progresses");

        builder.HasKey(p => new { p.UserId, p.StepId });

        builder.Property(p => p.UserId)
            .HasColumnName("user_id");

        builder.Property(p => p.StepId)
            .HasColumnName("step_id");

        builder.Property(p => p.IsPassed)
            .HasColumnName("is_passed");

        builder.Property(p => p.Score)
            .HasColumnName("score");

        builder.HasOne(p => p.User)
            .WithMany(u => u.Progresses)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.Step)
            .WithMany(s => s.Progresses)
            .HasForeignKey(p => p.StepId);
    }
}

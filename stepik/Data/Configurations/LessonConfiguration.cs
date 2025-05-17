using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasColumnName("id");

        builder.Property(l => l.Title)
            .HasColumnName("title");

        builder.Property(l => l.EpicCount)
            .HasColumnName("epic_count");

        builder.Property(l => l.AbuseCount)
            .HasColumnName("abuse_count");
    }
}

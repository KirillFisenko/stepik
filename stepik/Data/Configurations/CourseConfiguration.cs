using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Title)
            .HasColumnName("title")
            .HasMaxLength(50);

        builder.Property(c => c.CreatedDate)
            .HasColumnName("created_date");

        builder.Property(c => c.Summary)
            .HasColumnName("summary");

        builder.Property(c => c.Photo)
            .HasColumnName("photo");

        builder.Property(c => c.Price)
            .HasColumnName("price");
    }
}

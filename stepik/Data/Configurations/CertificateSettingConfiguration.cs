using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CertificateSettingConfiguration : IEntityTypeConfiguration<CertificateSetting>
{
    public void Configure(EntityTypeBuilder<CertificateSetting> builder)
    {
        builder.ToTable("certificate_settings");

        builder.HasKey(cs => cs.CourseId);

        builder.Property(cs => cs.CourseId)
            .HasColumnName("course_id");

        builder.Property(cs => cs.LogoUrl)
            .HasColumnName("logo_url");

        builder.Property(cs => cs.SignatureUrl)
            .HasColumnName("signature_url");

        builder.Property(cs => cs.IsCertificateAutoIssued)
            .HasColumnName("is_certificate_auto_issued");

        builder.Property(cs => cs.RegularThreshold)
            .HasColumnName("regular_threshold");

        builder.Property(cs => cs.ExcellentThreshold)
            .HasColumnName("excellent_threshold");

        builder.HasOne(cs => cs.Course)
            .WithOne(c => c.CertificateSetting)
            .HasForeignKey<CertificateSetting>(cs => cs.CourseId);
    }
}

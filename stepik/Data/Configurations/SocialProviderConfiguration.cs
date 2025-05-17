using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SocialProviderConfiguration : IEntityTypeConfiguration<SocialProvider>
{
    public void Configure(EntityTypeBuilder<SocialProvider> builder)
    {
        builder.ToTable("social_providers");

        builder.HasKey(sp => sp.Id);

        builder.Property(sp => sp.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(sp => sp.Name)
            .HasColumnName("name");

        builder.Property(sp => sp.LogoUrl)
            .HasColumnName("logo_url");
    }
}

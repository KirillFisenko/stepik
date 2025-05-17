using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserSocialProviderConfiguration : IEntityTypeConfiguration<UserSocialProvider>
{
    public void Configure(EntityTypeBuilder<UserSocialProvider> builder)
    {
        builder.ToTable("user_social_providers");

        builder.HasKey(usp => new { usp.UserId, usp.SocialProviderId });

        builder.Property(usp => usp.UserId)
            .HasColumnName("user_id");

        builder.Property(usp => usp.SocialProviderId)
            .HasColumnName("social_provider_id");

        builder.Property(usp => usp.ConnectUrl)
            .HasColumnName("connect_url");

        builder.HasOne(usp => usp.User)
            .WithMany(u => u.UserSocialProviders)
            .HasForeignKey(usp => usp.UserId);

        builder.HasOne(usp => usp.SocialProvider)
            .WithMany(sp => sp.UserSocialProviders)
            .HasForeignKey(usp => usp.SocialProviderId);
    }
}

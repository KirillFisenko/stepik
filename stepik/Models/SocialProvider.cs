using System.ComponentModel.DataAnnotations.Schema;

[Table("social_providers")]
public class SocialProvider
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("logo_url")]
    public string LogoUrl { get; set; }

    public List<UserSocialProvider> UserSocialProviders { get; set; }
}
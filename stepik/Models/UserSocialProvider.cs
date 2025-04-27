using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(UserId), nameof(SocialProviderId))]
[Table("user_social_providers")]
public class UserSocialProvider
{
    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    [Column("social_provider_id")]
    [ForeignKey(nameof(SocialProvider))]
    public int SocialProviderId { get; set; }

    [Column("connect_url")]
    public string ConnectUrl { get; set; }


    public User User { get; set; }
    public SocialProvider SocialProvider { get; set; }
}
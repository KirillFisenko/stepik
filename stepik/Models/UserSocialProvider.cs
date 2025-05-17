public class UserSocialProvider
{
    public int UserId { get; set; }
    public int SocialProviderId { get; set; }
    public string ConnectUrl { get; set; }

    public User User { get; set; }
    public SocialProvider SocialProvider { get; set; }
}

public class SocialProvider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }

    public List<UserSocialProvider> UserSocialProviders { get; set; }
}
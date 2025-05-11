namespace stepik.Services;

public static class ServiceProvider
{
    public static IUsersService usersService = new stepik.Services.EF.UsersService();
    public static ICoursesService coursesService = new stepik.Services.EF.CoursesService();
    public static ICertificatesService certificatesService = new stepik.Services.EF.CertificatesService();
    public static ICommentsService commentsService = new stepik.Services.EF.CommentsService();
    public static UsersProcessing usersProcessing = new();
    public static WrongChoice wrongChoice = new();
}
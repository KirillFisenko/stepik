namespace stepik.Services;

public static class ServiceProvider
{
    public static IUsersService usersService = new stepik.Services.ADO.NET.UsersService();
    public static ICoursesService coursesService = new stepik.Services.ADO.NET.CoursesService();
    public static ICertificatesService certificatesService = new stepik.Services.ADO.NET.CertificatesService();
    public static ICommentsService commentsService = new stepik.Services.ADO.NET.CommentsService();
    public static UsersProcessing usersProcessing = new();
    public static WrongChoice wrongChoice = new();
}
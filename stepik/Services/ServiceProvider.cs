namespace stepik.Services;
public class ServiceProvider
{
    public IUsersService usersService;
    public ICoursesService coursesService;
    public ICertificatesService certificatesService;
    public ICommentsService commentsService;
    public UsersProcessing usersProcessing;
    public WrongChoice wrongChoice;

    public ServiceProvider()
    {
        usersService = new stepik.Services.ADO.NET.UsersService();
        coursesService = new stepik.Services.ADO.NET.CoursesService();
        certificatesService = new stepik.Services.ADO.NET.CertificatesService();
        commentsService = new stepik.Services.ADO.NET.CommentsService();
        usersProcessing = new UsersProcessing(usersService);
        wrongChoice = new();
    }
}
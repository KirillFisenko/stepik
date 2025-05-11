using stepik.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICertificatesService, stepik.Services.EF.CertificatesService>();
builder.Services.AddTransient<ICommentsService, stepik.Services.EF.CommentsService>();
builder.Services.AddTransient<ICoursesService, stepik.Services.EF.CoursesService>();
builder.Services.AddTransient<IUsersService, stepik.Services.EF.UsersService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

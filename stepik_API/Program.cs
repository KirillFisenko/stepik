using stepik.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICertificatesService, stepik.Services.ADO.NET.CertificatesService>();
builder.Services.AddTransient<ICommentsService, stepik.Services.ADO.NET.CommentsService>();
builder.Services.AddTransient<ICoursesService, stepik.Services.ADO.NET.CoursesService>();
builder.Services.AddTransient<IUsersService, stepik.Services.ADO.NET.UsersService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

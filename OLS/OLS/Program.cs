using Microsoft.EntityFrameworkCore;
using OLS.Models;
using OLS.Repositories.Implementations.Admin;
using OLS.Repositories.Implementations.Home;
using OLS.Repositories.Interface.Admin;
using OLS.Repositories.Interface.Home;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Config dbcontext - ms sql server
builder.Services.AddDbContext<OLSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

// <Admin>
builder.Services.AddScoped<IUserManagerRepository, UserManagerRepository>();
builder.Services.AddScoped<ICourseManagerRepository, CourseManagerRepository>();
builder.Services.AddScoped<IChapterManagerRepository, ChapterManagerRepository>();
builder.Services.AddScoped<ILessonManagerRepository, LessonManagerRepository>();
// <Admin>

// <Home>
// Config Repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILearningPathRepository, LearningPathRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
// <Home>

// Config Cors reactjs default port 3000
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3003")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // Allow credentials (cookies, authorization headers)
    });
});

// Config Automapper
// <Summary>
//dòng code này có ý nghĩa là bạn đang thêm dịch vụ của AutoMapper vào ứng dụng ASP.NET Core của mình
//và cấu hình nó để tự động ánh xạ giữa các đối tượng trong ứng dụng mà không cần phải viết mã ánh xạ chi tiết.
// <Summary>
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddIdentity<User, Userrole>()
//       .AddDefaultTokenProviders();

//builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
//builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
//builder.Services.AddTransient<RoleManager<Userrole>, RoleManager<Userrole>>();
//builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CROS - Config Cors reactjs default port 3000
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

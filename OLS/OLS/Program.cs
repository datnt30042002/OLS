using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OLS.Models;
using OLS.Services.Implementations.Admin;
using OLS.Services.Implementations.Home;
using OLS.Services.Interface.Admin;
using OLS.Services.Interface.Home;
using OLS.Ultils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Config dbcontext - ms sql server
builder.Services.AddDbContext<OLSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

// Config Repositories
// <Admin>
builder.Services.AddScoped<IUserManagerRepository, UserManagerRepository>();
builder.Services.AddScoped<ICourseManagerRepository, CourseManagerRepository>();
builder.Services.AddScoped<IChapterManagerRepository, ChapterManagerRepository>();
builder.Services.AddScoped<ILessonManagerRepository, LessonManagerRepository>();
builder.Services.AddScoped<IBlogManagerRepository, BlogManagerRepository>();
builder.Services.AddScoped<IQuizManagerRepository, QuizManagerRepository>();
builder.Services.AddScoped<IQuestionManagerRepository, QuestionManagerRepository>();
builder.Services.AddScoped<IAnswerManagerRepository,  AnswerManagerRepository>();
builder.Services.AddScoped<IFeedbackManagerRepository, FeedbackManagerRepository>();
builder.Services.AddScoped<INotificationManagerRepository, NotificationManagerRepository>();
builder.Services.AddScoped<IRateStarManagerRepository,  RateStarManagerRepository>();
// <Admin>

// <Home>
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILearningPathRepository, LearningPathRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseEnrolledRepository, CourseEnrolledRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IDiscussRepository, DiscussRepository>();
builder.Services.AddScoped<IAskRepository, AskRepository>();
builder.Services.AddScoped<IReplyRepository, ReplyRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IRateStarRepository, RateStarRepository>();
// <Home>

builder.Services.AddScoped<HashPassMD5, HashPassMD5>();
builder.Services.AddScoped<Mailer, Mailer>();
builder.Services.AddScoped<Mapper, Mapper>();

// Config Cors ReactJS default port 3003
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

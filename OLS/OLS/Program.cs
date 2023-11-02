using Microsoft.EntityFrameworkCore;
using OLS.Models;
using OLS.Repositories.Implementations;
using OLS.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Config dbcontext - ms sql server
builder.Services.AddDbContext<OLSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

// Config Repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILearningPathRepository, LearningPathRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

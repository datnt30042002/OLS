using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OLS.Models;
//using OLS.Models;
//using OLS.Repositories.Interface;
//using OLS.Repositories.Object;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

/*
 * cũ
builder.Services.AddDbContext<f8dbContext>(options =>
{
    IConfiguration configuration = builder.Configuration.GetSection("ConnectionStrings");
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
*/


// Configure the DbContext - mới
builder.Services.AddDbContext<f8dbContext>(options =>
{
    IConfiguration configuration = builder.Configuration;
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddIdentity<User, Userrole>()
//       .AddDefaultTokenProviders();

//builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
//builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
//builder.Services.AddTransient<RoleManager<Userrole>, RoleManager<Userrole>>();
//builder.Services.AddTransient<IUserRepository, UserRepository>();

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

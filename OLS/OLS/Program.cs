using Microsoft.EntityFrameworkCore;
using OLS.Models;
//using OLS.Repositories.Interface;
//using OLS.Repositories.Object;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// config dbcontext - ms sql server
builder.Services.AddDbContext<F8DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

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

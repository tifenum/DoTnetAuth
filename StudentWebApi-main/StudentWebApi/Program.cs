using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<StudentDB>(
                        options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

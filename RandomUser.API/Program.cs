using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using RandomUser.Application.Mapper;
using RandomUser.Domain.Services;
using RandomUser.Application.Services;
using RandomUser.Infrastructure.Repositories;
using RandomUser.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection>(db => new NpgsqlConnection(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Services 
builder.Services.AddScoped<IGenerateUserService, GenerateUserService>();
builder.Services.AddScoped<IUserService, UserService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

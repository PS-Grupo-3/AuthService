using Application.Interfaces.AuthInterface;
using Infrastructure.Persistence;
using Infrastructure.Commands.AuthCommand;
using Infrastructure.Querys.AuthQuery;
using Microsoft.EntityFrameworkCore;
using Application.UseCase.AuthUseCase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAuthCommand, AuthCommands>();
builder.Services.AddScoped<IAuthQuery, AuthQuerys>();
builder.Services.AddScoped<IAuthService, AuthService>();

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

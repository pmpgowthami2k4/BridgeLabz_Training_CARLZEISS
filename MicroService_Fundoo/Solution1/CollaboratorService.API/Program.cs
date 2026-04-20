using CollaboratorService.Application.Interfaces;
using CollaboratorService.Application.Services;
using CollaboratorService.Infrastructure.Data;
using CollaboratorService.Infrastructure.Repositories;
using CollaboratorService.Infrastructure.RabbitMQ;
using CollaboratorService.Infrastructure.Email;
using SharedLibrary.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Configuration
builder.Services.AddSingleton<DbConnectionFactory>();

// Dependency Injection
builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
builder.Services.AddScoped<CollaboratorManager>();

// RabbitMQ + Email Services
builder.Services.AddSingleton<RabbitMqPublisher>();
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseGlobalExceptionMiddleware();
app.MapControllers();

// Redirect root → Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
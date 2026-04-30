//using CollaboratorService.Application.Interfaces;
//using CollaboratorService.Application.Services;
//using CollaboratorService.Infrastructure.Data;
//using CollaboratorService.Infrastructure.Repositories;
//using CollaboratorService.Infrastructure.RabbitMQ;
//using CollaboratorService.Infrastructure.Email;
//using SharedLibrary.Extensions;

//var builder = WebApplication.CreateBuilder(args);

//// Add Services
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Database
//builder.Services.AddSingleton<DbConnectionFactory>();

//// DI
//builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
//builder.Services.AddScoped<CollaboratorManager>();

//// RabbitMQ + Email
//builder.Services.AddSingleton<RabbitMqPublisher>();
//builder.Services.AddScoped<EmailService>();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.UseGlobalExceptionMiddleware();

//app.MapControllers();

//app.MapGet("/", () => Results.Redirect("/swagger"));

//app.Run();

using CollaboratorService.Application.Interfaces;
using CollaboratorService.Application.Services;
using CollaboratorService.Infrastructure.Data;
using CollaboratorService.Infrastructure.Repositories;
using CollaboratorService.Infrastructure.RabbitMQ;
using CollaboratorService.Infrastructure.Email;
using Dapr.Client;
using SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddControllers().AddDapr(); // 🔥 FIX
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dapr
builder.Services.AddDaprClient();

// Database
builder.Services.AddSingleton<DbConnectionFactory>();

// DI
builder.Services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
builder.Services.AddScoped<CollaboratorManager>();

// Email
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();          // 🔥 ADD THIS
app.UseCloudEvents();      // 🔥 FIX (CRITICAL)

app.UseGlobalExceptionMiddleware();

app.MapSubscribeHandler(); // 🔥 already correct
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
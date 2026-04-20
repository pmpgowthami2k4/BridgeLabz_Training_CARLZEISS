using LabelService.Application.Interfaces;
using LabelService.Application.Services;
using LabelService.Infrastructure.Data;
using LabelService.Infrastructure.Repositories;
using SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<LabelManager>();
builder.Services.AddScoped<INoteLabelRepository, NoteLabelRepository>();
builder.Services.AddScoped<NoteLabelManager>();

var app = builder.Build();

//middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseGlobalExceptionMiddleware();
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
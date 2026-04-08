using System.Data;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataBaseLayer.Interfaces;
using DataBaseLayer.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// DB CONNECTION
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTER DL
builder.Services.AddScoped<IStudentDL, StudentDL>();
builder.Services.AddScoped<IEnrollmentDL, EnrollmentDL>();
builder.Services.AddScoped<ICourseDL, CourseDL>();



//register BL
builder.Services.AddScoped<IStudentBL, StudentBL>();
builder.Services.AddScoped<IEnrollmentBL, EnrollmentBL>();
builder.Services.AddScoped<ICourseBL, CourseBL>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//redirect to swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
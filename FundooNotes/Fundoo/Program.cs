
using System.Data;
using System.Text;
using BusinessLayer.Cache;
using BusinessLayer.Interfaces;
using BusinessLayer.RabbitMQ;
using BusinessLayer.Service;
using DataBaseLayer.Interfaces;
using DataBaseLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using DataBaseLayer.Context;
using StackExchange.Redis;






var builder = WebApplication.CreateBuilder(args);


//REDIS
builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"])
);

// 🔹 Add services to the container
builder.Services.AddControllers();

// 🔹 Register Dapper DB Connection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Register Business Layer
builder.Services.AddTransient<INoteBL, NoteBL>();
builder.Services.AddTransient<IUserBL, UserBL>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<ILabelBL, LabelBL>();
builder.Services.AddTransient<ICollaboratorBL, CollaboratorBL>();
builder.Services.AddScoped<INotesLabelBL, NotesLabelBL>(); 
builder.Services.AddScoped<INotesLabelBL, NotesLabelBL>();
builder.Services.AddScoped<IReminderBL, ReminderBL>();


// 🔹 Register Data Layer
builder.Services.AddTransient<INoteDL, NoteDL>();
builder.Services.AddTransient<IUserDL, UserDL>();
builder.Services.AddTransient<ILabelDL, LabelDL>();
builder.Services.AddTransient<ICollaboratorDL, CollaboratorDL>();
builder.Services.AddScoped<INotesLabelDL, NotesLabelDL>();
builder.Services.AddScoped<IReminderDL, ReminderDL>();
builder.Services.AddTransient<IUserDL, UserDL>();

//register RABBITMQ 
builder.Services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
builder.Services.AddHostedService<RabbitMQConsumer>();

//register MONGO
//builder.Services.AddSingleton<MongoContext>();




// 🔹 Swagger
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();


var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

// 🔹 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Redirect root → Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
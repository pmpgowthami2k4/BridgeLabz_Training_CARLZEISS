using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NotesService.Infrastructure.Data;
using NotesService.Infrastructure.Repositories;
using NotesService.Application.Interfaces;
using StackExchange.Redis;
using NotesService.Infrastructure.Cache;
using System.Text;
using SharedLibrary.Extensions;


var builder = WebApplication.CreateBuilder(args);

// -------------------- Controllers --------------------
builder.Services.AddControllers();

// -------------------- Swagger --------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------- MongoDB Configuration --------------------
var mongoSettings = builder.Configuration
    .GetSection("MongoSettings")
    .Get<MongoSettings>();

builder.Services.AddSingleton(mongoSettings!);
builder.Services.AddSingleton<MongoDbContext>();

// -------------------- Redis --------------------
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect("host.docker.internal:6379")
);

builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

// -------------------- Dependency Injection --------------------
builder.Services.AddScoped<INoteRepository, NoteRepository>();
                                
// -------------------- JWT Authentication --------------------
var key = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key!)
        ),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseGlobalExceptionMiddleware();

// -------------------- Middleware --------------------
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

// 🔥 ORDER MATTERS
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Redirect root → Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
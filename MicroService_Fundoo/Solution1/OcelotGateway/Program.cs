//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;
//using System.Text;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;

//var builder = WebApplication.CreateBuilder(args);

//// Load Ocelot Config
//builder.Configuration
//    .SetBasePath(builder.Environment.ContentRootPath)
//    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
//    .AddEnvironmentVariables();

//// Services
//builder.Services.AddOcelot(builder.Configuration);

//// Swagger (optional local UI only)
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Swagger UI
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

//app.UseSwagger();
//app.UseSwaggerUI();

//// Root redirect
//app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

//// Ocelot MUST be last
//await app.UseOcelot();

//app.Run();


using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot Config
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");

// Services
builder.Services.AddOcelot(builder.Configuration);

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Secret"]!))
    };
});

builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Auth Middleware
app.UseAuthentication();
app.UseAuthorization();

// Root redirect
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

// Ocelot LAST
await app.UseOcelot();

app.Run();
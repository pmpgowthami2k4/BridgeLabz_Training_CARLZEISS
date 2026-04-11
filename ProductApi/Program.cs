using ProductApi.Services;
using ProductApi.Repositories;
var builder = WebApplication.CreateBuilder(args); //Create the application and prepare services

// Add services to the container
builder.Services.AddControllers(); //Enable controllers (so API endpoints can work)
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepository>();


// Swagger setup 1
builder.Services.AddEndpointsApiExplorer(); //Enable API endpoint exploration for Swagger //Scan my app and find all API endpoints, so tools like Swagger can understand them.
builder.Services.AddSwaggerGen(); //Enable Swagger UI to test APIs

var app = builder.Build(); // Now build the actual app using all configurations

// Configure middleware Swagger 2
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
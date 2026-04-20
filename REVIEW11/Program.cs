using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 



// Swagger setup 1
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

var app = builder.Build(); 

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







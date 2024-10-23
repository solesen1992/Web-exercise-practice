/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Demo_SecureWebApiUsingJWTToken;

/*
 * CODE ALONG SESSION
 * Credit: https://www.youtube.com/watch?v=h2hGGPHLqqc
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Call the JWT authentication extension method
builder.Services.AddJwtAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Enable authentication middleware - if you are who you claim to be
app.UseAuthorization();  // Enable authorization middleware - telling what resources the user has access to

app.MapControllers();

app.Run();
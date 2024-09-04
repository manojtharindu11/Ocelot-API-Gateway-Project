using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services required for controllers and API Explorer
builder.Services.AddEndpointsApiExplorer();

// Add Ocelot services and load configuration from ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

// Configure the application

// Redirect HTTP to HTTPS (if needed)
app.UseHttpsRedirection();

app.UseAuthorization();

// Map controllers defined in your application
app.MapControllers();

// Use Ocelot middleware to handle API gateway functionality
await app.UseOcelot();

// Run the application
app.Run();

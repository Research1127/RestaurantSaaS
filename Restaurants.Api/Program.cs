using Microsoft.OpenApi.Models;
using Restaurants.Api.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Restaurants.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);


// ADD THIS BEFORE ANY OTHER SERVICE REGISTRATION FOR DOCKER PORT BINDING
builder.WebHost.ConfigureKestrel(options =>
{
    // Docker container port
    options.ListenAnyIP(80);

    // Local development ports (optional)
    options.ListenLocalhost(5204); 
    options.ListenLocalhost(5000);   // HTTP
    options.ListenLocalhost(5001);   // HTTPS (optional)
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// CORS SETUP

// Read frontend URL from environment variable
var frontendUrl = builder.Configuration["FRONTEND_URL"];

// Configure CORS using the env variable
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.WithOrigins(frontendUrl ?? "http://localhost:3000") // React URL
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// -------
builder.AddPresentation();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

        

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();   // Must put first in our Http request pipeline
app.UseMiddleware<RequestTimeLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

// ✅ ADD THIS CORS SETUP
app.UseCors("AllowReact");

app.UseAuthorization();
app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.MapControllers();

app.Run();


using Presentation;
using Application;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

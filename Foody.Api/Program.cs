using Foody.Application;
using Foody.Infrastructure;
using InfrastructureDependencyInjection = Foody.Infrastructure.DependancyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
InfrastructureDependencyInjection.AddInfrastructureServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

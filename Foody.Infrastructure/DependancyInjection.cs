using Foody.Application.Authentication;
using Foody.Application.Common.Interfaces;
using Foody.Application.Common.Interfaces.Persistance;
using Foody.Application.Common.Services;
using Foody.Infrastructure.Authentication;
using Foody.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Foody.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository,UserRepository>();
        return services;
    }
}

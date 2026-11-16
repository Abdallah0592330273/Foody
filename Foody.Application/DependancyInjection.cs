using Foody.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Foody.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}


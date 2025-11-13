using eCommerce.Application.Services;
using eCommerce.Application.ServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //TODO: add service to IoC container
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}
using eCommerce.Application.Mappers;
using eCommerce.Application.Services;
using eCommerce.Application.ServicesInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //TODO: add service to IoC container
        // var appAssembly = typeof(AppUserMappingProfile).Assembly;
        services.AddAutoMapper(cfg => { }, typeof(AppUserMappingProfile));
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}
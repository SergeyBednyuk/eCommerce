using eCommerce.Application.Dtos;
using eCommerce.Application.Mappers;
using eCommerce.Application.Services;
using eCommerce.Application.ServicesInterfaces;
using eCommerce.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //TODO: add service to IoC container
        //Deprecated
        // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddAutoMapper(cfg => { }, typeof(AppUserMappingProfile));
        services.AddScoped<IUserService, UserService>();
        
        // services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
        services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        return services;
    }
}
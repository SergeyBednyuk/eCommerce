using eCommerce.Domain.RepositoriesInterfaces;
using eCommerce.infrastructure.DbContext;
using eCommerce.infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: add services to IoC container
        services.AddTransient<DapperDbContext>();
        services.AddScoped<IUsersRepository, UserRepository>();
        
        return services;
    }
}
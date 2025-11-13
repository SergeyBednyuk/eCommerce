using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: add services to IoC container
        
        return services;
    }
}
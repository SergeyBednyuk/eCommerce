using eCommerce.Api.Middlewares;
using eCommerce.Application;
using eCommerce.infrastructure;

namespace eCommerce.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        //add services registration
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication();
        builder.Services.AddControllers();
        
        var app = builder.Build();

        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        
        //Routing
        app.UseRouting();
        
        //Auth
        app.UseAuthentication();
        app.UseAuthorization();
        
        //Controller routing
        app.MapControllers();
        
        //Run the app
        app.Run();
    }
}
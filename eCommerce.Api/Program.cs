using System.Text.Json.Serialization;
using eCommerce.Api.Middlewares;
using eCommerce.Application;
using eCommerce.Application.Mappers;
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
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            });
        });
        
        //Add API explorer services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();

        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        
        //Routing
        app.UseRouting();
        
        //Swagger
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseCors();
        
        //Auth
        app.UseAuthentication();
        app.UseAuthorization();
        
        //Controller routing
        app.MapControllers();
        
        //Run the app
        app.Run();
    }
}
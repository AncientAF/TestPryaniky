using Serilog;
using TestPryaniky.API.Exceptions;
using TestPryaniky.API.Extensions;

namespace TestPryaniky.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var seqString = configuration.GetConnectionString("Seq")!;
        
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Seq(seqString)
            .ReadFrom.Configuration(configuration).CreateLogger();

        services.AddSerilog();
        
        services.AddExceptionHandler<ExceptionHandler>();
        services.AddProblemDetails();
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static async Task<WebApplication> UseApiServices(this WebApplication app)
    {
        app.UseExceptionHandler();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();
        
        await app.InitialiseDatabaseAsync();
        
        return app;
    }
}

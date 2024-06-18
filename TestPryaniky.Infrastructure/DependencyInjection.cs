using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestPryaniky.Core.Repositories;
using TestPryaniky.Infrastructure.Interceptors;
using TestPryaniky.Infrastructure.Repositories;

namespace TestPryaniky.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Database");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connection);
        });
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}
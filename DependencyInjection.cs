using MyApplication.Services.Orders;

namespace MyApplication;

public static class DependencyInjection
{
    
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IOrdersService, OrdersService>();
        return services;
    }
    
}
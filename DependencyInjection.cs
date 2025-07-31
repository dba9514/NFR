using MyApplication.Services.Dialogs;
using MyApplication.Services.Orders;

namespace MyApplication;

public static class DependencyInjection
{
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IOrdersService, OrdersService>();
        services.AddTransient<INfrDialogService, NfrDialogService>();
        return services;
    }
    
}
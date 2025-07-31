using MyApplication.Services.Dialogs;
using MyApplication.Services.Orders;

namespace MyApplication;

/// <summary>
/// Provides methods for configuring dependency injection for the application.
/// </summary>
public static class DependencyInjection
{
    
    /// <summary>
    /// Registers application services with the provided <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which application services should be added.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> with the registered services.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IOrdersService, OrdersService>();
        services.AddTransient<INfrDialogService, NfrDialogService>();
        return services;
    }
    
}
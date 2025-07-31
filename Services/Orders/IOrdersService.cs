using MyApplication.Models.Orders;
using ErrorOr;

namespace MyApplication.Services.Orders;

public interface IOrdersService
{
    
    Task<ErrorOr<OrderModel>> GetOrderByIdAsync(int orderId);
    Task<ErrorOr<OrderModel>> UpdateOrderAsync(OrderModel request);
    Task<CreateOrderItemForm?> OpenCreateOrderItemDialogAsync();
    Task<UpdateOrderItemForm?> OpenUpdateOrderItemDialogAsync(UpdateOrderItemForm updateForm);
    
}
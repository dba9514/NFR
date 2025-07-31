using ErrorOr;
using MyApplication.Models.Orders;
using MyApplication.Utilities;

namespace MyApplication.Services.Orders;

public class OrdersService: IOrdersService
{
    public async Task<ErrorOr<OrderModel>> GetOrderByIdAsync(int orderNumber)
    {
        var orderToReturn = MockData.Orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        if(orderToReturn == null) return Error.NotFound("404", "Order Not Found");
        return orderToReturn;
    }

    public async Task<ErrorOr<OrderModel>> UpdateOrderAsync(OrderModel request)
    {
        var orderToUpdate = MockData.Orders.FirstOrDefault(o => o.Id == request.Id);
        if(orderToUpdate == null) return Error.NotFound("404", "Order Not Found");

        MockData.Orders.Remove(orderToUpdate);
        MockData.Orders.Add(request);
        return request;
    }
}
using ErrorOr;
using MudBlazor;
using MyApplication.Components.ReusableComponents.Orders;
using MyApplication.Models.Orders;
using MyApplication.Utilities;

namespace MyApplication.Services.Orders;

public class OrdersService(IDialogService dialogService): IOrdersService
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
    
    public async Task<CreateOrderItemForm?> OpenCreateOrderItemDialogAsync()
    {
        var dialogOptions = new DialogOptions
        {
            CloseOnEscapeKey = false,
            BackdropClick = false,
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            CloseButton = false
        };
        
        
        
        var dialog = await dialogService.ShowAsync<CreateOrderDialog>("Create Order Line Item", dialogOptions);
        var result = await dialog.Result;

        if (result is not null && !result.Canceled && result.Data is CreateOrderItemForm newItem)
        {
            return newItem;
        }

        return null;
    }

    public async Task<UpdateOrderItemForm?> OpenUpdateOrderItemDialogAsync(UpdateOrderItemForm updateForm)
    {
        var dialogOptions = new DialogOptions
        {
            CloseOnEscapeKey = false,
            BackdropClick = false,
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            CloseButton = false
        };
        

        var parameters = new DialogParameters<UpdateOrderDialog>
        {
            { x => x.UpdateOrderItemForm, updateForm }
        };
        
        var dialog = await dialogService.ShowAsync<UpdateOrderDialog>("Update Order Line Item", parameters, dialogOptions);
        var result = await dialog.Result;

        if (result is not null && !result.Canceled && result.Data is UpdateOrderItemForm newItem)
        {
            return newItem;
        }

        return null;
    }
}
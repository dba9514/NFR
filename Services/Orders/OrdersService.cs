using ErrorOr;
using MudBlazor;
using MyApplication.Components.ReusableComponents.Orders;
using MyApplication.Models.Orders;
using MyApplication.Utilities;

namespace MyApplication.Services.Orders;

/// <summary>
/// Service for managing orders and providing dialog interactions for creating or updating order line items.
/// </summary>
public class OrdersService(IDialogService dialogService): IOrdersService
{
    /// <summary>
    /// Retrieves an order by its unique order number.
    /// </summary>
    /// <param name="orderNumber">The unique number identifying the order.</param>
    /// <returns>An <see cref="ErrorOr{OrderModel}"/> representing the order, or an error if not found.</returns>
    public async Task<ErrorOr<OrderModel>> GetOrderByIdAsync(int orderNumber)
    {
        var orderToReturn = MockData.Orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        if(orderToReturn == null) return Error.NotFound("404", "Order Not Found");
        return orderToReturn;
    }

    /// <summary>
    /// Updates an existing order with the provided data.
    /// </summary>
    /// <param name="request">The updated order data.</param>
    /// <returns>An <see cref="ErrorOr{OrderModel}"/> representing the updated order, or an error if the order is not found.</returns>
    public async Task<ErrorOr<OrderModel>> UpdateOrderAsync(OrderModel request)
    {
        var orderToUpdate = MockData.Orders.FirstOrDefault(o => o.Id == request.Id);
        if(orderToUpdate == null) return Error.NotFound("404", "Order Not Found");
    
        MockData.Orders.Remove(orderToUpdate);
        MockData.Orders.Add(request);
        return request;
    }
    
    /// <summary>
    /// Opens a dialog to create a new order line item.
    /// </summary>
    /// <returns>A <see cref="CreateOrderItemForm"/> object if successful, or null if the dialog is canceled.</returns>
    public async Task<CreateOrderItemForm?> OpenCreateOrderItemDialogAsync()
    {
        var dialogOptions = new DialogOptions
        {
            CloseOnEscapeKey = false,
            BackdropClick = false,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            CloseButton = true
        };
        
        
        
        var dialog = await dialogService.ShowAsync<CreateOrderDialog>("Create Order Line Item", dialogOptions);
        var result = await dialog.Result;
    
        if (result is not null && !result.Canceled && result.Data is CreateOrderItemForm newItem)
        {
            return newItem;
        }
    
        return null;
    }

    /// <summary>
    /// Opens a dialog to update an existing order line item.
    /// </summary>
    /// <param name="updateForm">The form containing the data to update the order line item.</param>
    /// <returns>An <see cref="UpdateOrderItemForm"/> object if successful, or null if the dialog is canceled.</returns>
    public async Task<UpdateOrderItemForm?> OpenUpdateOrderItemDialogAsync(UpdateOrderItemForm updateForm)
    {
        var dialogOptions = new DialogOptions
        {
            CloseOnEscapeKey = false,
            BackdropClick = false,
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            CloseButton = true
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
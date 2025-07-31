using MyApplication.Models.Orders;
using ErrorOr;

namespace MyApplication.Services.Orders;

public interface IOrdersService
{
    
    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="orderId">The unique identifier for the order.</param>
    /// <returns>An <see cref="ErrorOr{T}"/> containing the order model if found, or an error if not.</returns>
    Task<ErrorOr<OrderModel>> GetOrderByIdAsync(int orderId);
    /// <summary>
    /// Updates an existing order with new details.
    /// </summary>
    /// <param name="request">The updated order model.</param>
    /// <returns>An <see cref="ErrorOr{T}"/> containing the updated order model if successful, or an error if not.</returns>
    Task<ErrorOr<OrderModel>> UpdateOrderAsync(OrderModel request);
    /// <summary>
    /// Opens a dialog for creating a new order item.
    /// </summary>
    /// <returns>A <see cref="CreateOrderItemForm"/> representing the created order item, or null if the dialog is canceled.</returns>
    Task<CreateOrderItemForm?> OpenCreateOrderItemDialogAsync();
    /// <summary>
    /// Opens a dialog for updating an existing order item.
    /// </summary>
    /// <param name="updateForm">The current details of the order item to be updated.</param>
    /// <returns>A <see cref="UpdateOrderItemForm"/> with updated order item details, or null if the dialog is canceled.</returns>
    Task<UpdateOrderItemForm?> OpenUpdateOrderItemDialogAsync(UpdateOrderItemForm updateForm);
    
}
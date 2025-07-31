
namespace MyApplication.Models.Orders;

/// <summary>
/// Represents a form for creating an order item.
/// </summary>
public class CreateOrderItemForm
{
    /// <summary>
    /// Unique identifier for the order item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The type of the order line associated with the item.
    /// </summary>
    public OrderLineTypes LineType { get; set; }

    /// <summary>
    /// Additional details or description of the order item.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the order item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The price per individual unit of the order item.
    /// </summary>
    public double IndividualPrice { get; set; }

    /// <summary>
    /// The total price calculated as Quantity multiplied by IndividualPrice.
    /// </summary>
    public double TotalPrice => Quantity * IndividualPrice;

    /// <summary>
    /// Converts the current form into an <see cref="OrderItemModel"/>.
    /// </summary>
    /// <returns>An <see cref="OrderItemModel"/> instance containing the form's data.</returns>
    public OrderItemModel ToModel()
    {
        return new OrderItemModel(Id, LineType, Details, Quantity, IndividualPrice);
    }
    
}
namespace MyApplication.Models.Orders;

/// <summary>
/// Represents a form to update an order item.
/// The form is typically bound to an update interface for verifying updates 
/// and additional validations/parameters.
/// </summary>
public class UpdateOrderItemForm
{
    /// <summary>
    /// Gets or sets the unique identifier of the order item being updated.
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// Gets or sets the type of the order line.
    /// Defines the category/type of the order item.
    /// </summary>
    public OrderLineTypes LineType { get; set; } = OrderLineTypes.Default;

    /// <summary>
    /// Gets or sets a string that provides details about the order item.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of items in the order.
    /// Indicates how many units of this item are included in the order.
    /// </summary>
    public int Quantity { get; set; } = 0;

    /// <summary>
    /// Gets or sets the price of a single item in the order.
    /// </summary>
    public double IndividualPrice { get; set; } = 0.0;

    /// <summary>
    /// Gets the total price of the order item.
    /// Calculated as <c>Quantity * IndividualPrice</c>.
    /// </summary>
    public double TotalPrice => Quantity * IndividualPrice;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrderItemForm"/> class
    /// with specified property values.
    /// </summary>
    /// <param name="id">The unique identifier for the order item.</param>
    /// <param name="lineType">The type of the order line.</param>
    /// <param name="details">Details about the order item.</param>
    /// <param name="quantity">The quantity of the order item.</param>
    /// <param name="individualPrice">The price per unit of the order item.</param>
    public UpdateOrderItemForm(int id, OrderLineTypes lineType, string details, int quantity, double individualPrice)
    {
        Id = id;
        LineType = lineType;
        Details = details;
        Quantity = quantity;
        IndividualPrice = individualPrice;
    } 
    
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrderItemForm"/> class
    /// with default property values.
    /// </summary>
    public UpdateOrderItemForm()
    {
        
    }

    /// <summary>
    /// Converts the update form to an <see cref="OrderItemModel"/>.
    /// This allows working with the order item in its standard model format.
    /// </summary>
    /// <returns>An <see cref="OrderItemModel"/> representation of the form.</returns>
    public OrderItemModel ToModel()
    {
        return new OrderItemModel(Id, LineType, Details, Quantity, IndividualPrice);
    }
    
}
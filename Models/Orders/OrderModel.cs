using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models.Orders;



/// <summary>
/// Represents an order in the system.
/// </summary>
public class OrderModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the order number.
    /// </summary>
    public int OrderNumber { get; set; }

    /// <summary>
    /// Gets or sets the list of items associated with the order.
    /// </summary>
    public List<OrderItemModel> Items { get; set; }
}


/// <summary>
/// Represents an individual item in an order.
/// </summary>
public class OrderItemModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the order item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the order line.
    /// </summary>
    public OrderLineTypes LineType { get; set; }

    /// <summary>
    /// Gets or sets the details or description of the item.
    /// </summary>
    public string Details { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the price of an individual item.
    /// </summary>
    public double IndividualPrice { get; set; }

    /// <summary>
    /// Gets the total price of the item by multiplying quantity and individual price.
    /// </summary>
    public double TotalPrice => Quantity * IndividualPrice;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderItemModel"/> class.
    /// </summary>
    /// <param name="id">The identifier of the item.</param>
    /// <param name="lineType">The type of the order line.</param>
    /// <param name="details">The description or details of the item.</param>
    /// <param name="quantity">The quantity of the item.</param>
    /// <param name="individualPrice">The individual price of the item.</param>
    public OrderItemModel(int id, OrderLineTypes lineType, string details, int quantity, double individualPrice)
    {
        Id = id;
        LineType = lineType;
        Details = details;
        Quantity = quantity;
        IndividualPrice = individualPrice;
    }

    /// <summary>
    /// Converts the current order item to an <see cref="UpdateOrderItemForm"/>.
    /// </summary>
    /// <returns>A new <see cref="UpdateOrderItemForm"/> instance with the same data.</returns>
    public UpdateOrderItemForm ToUpdateForm()
    {
        return new UpdateOrderItemForm(id: Id, lineType: LineType, details: Details, quantity: Quantity, individualPrice: IndividualPrice);
    }

    /// <summary>
    /// Returns a string representation of the order item.
    /// </summary>
    /// <returns>A string representation of the order item.</returns>
    
    //For searching on
    public override string ToString()
    {
        return $"Id: {Id}, LineType: {LineType}, Details: {Details}, Quantity: {Quantity}, IndividualPrice: {IndividualPrice:C}, TotalPrice: {TotalPrice:C}";
    }

    
}

/// <summary>
/// Defines the types of order lines available for an order item.
/// </summary>
public enum OrderLineTypes
{
    /// <summary>
    /// Default order line type.
    /// </summary>
    Default,

    /// <summary>
    /// Repair a window.
    /// </summary>
    [Display(Name = "Repair Window")]
    RepairWindow,

    /// <summary>
    /// Install a dehumidifier.
    /// </summary>
    [Display(Name = "Install Dehumidifier")]
    InstallDehumidifier,

    /// <summary>
    /// Install door locks.
    /// </summary>
    [Display(Name = "Install Door Locks")]
    InstallDoorLocks,

    /// <summary>
    /// Install a fan.
    /// </summary>
    [Display(Name = "Install Fan")]
    InstallFan,

    /// <summary>
    /// Paint a room.
    /// </summary>
    [Display(Name = "Paint Room")]
    PaintRoom,

    /// <summary>
    /// Install flooring.
    /// </summary>
    [Display(Name = "Install Flooring")]
    InstallFlooring,

    /// <summary>
    /// Repair plumbing.
    /// </summary>
    [Display(Name = "Repair Plumbing")]
    RepairPlumbing
}
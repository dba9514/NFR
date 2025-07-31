namespace MyApplication.Models.Orders;



public class OrderModel
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public List<OrderItemModel> Items { get; set; }
}


public class OrderItemModel
{
    public int Id { get; set; }
    public OrderLineTypes LineType { get; set; }
    public string Details { get; set; }
    public int Quantity { get; set; }
    public decimal IndividualPrice { get; set; }
    public decimal TotalPrice => Quantity * IndividualPrice;
    
    public OrderItemModel(int id, OrderLineTypes lineType, string details, int quantity, decimal individualPrice)
    {
        Id = id;
        LineType = lineType;
        Details = details;
        Quantity = quantity;
        IndividualPrice = individualPrice;
    }

    public UpdateOrderItemForm ToUpdateForm()
    {
        return new UpdateOrderItemForm(id: Id, lineType: LineType, details: Details, quantity: Quantity, individualPrice: IndividualPrice);
    }
    
}

public enum OrderLineTypes
{
    RepairWindow,
    InstallDehumidifier,
    InstallDoorLocks
}
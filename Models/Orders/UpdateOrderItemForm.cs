namespace MyApplication.Models.Orders;

//This is a class to be bound to update forms
// Additional validation / parameters could be associated directly with updates.
public class UpdateOrderItemForm
{
    public int Id { get; set; }
    public OrderLineTypes LineType { get; set; }
    public string Details { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal IndividualPrice { get; set; }
    public decimal TotalPrice => Quantity * IndividualPrice;
    
    public UpdateOrderItemForm(int id, OrderLineTypes lineType, string details, int quantity, decimal individualPrice)
    {
        Id = id;
        LineType = lineType;
        Details = details;
        Quantity = quantity;
        IndividualPrice = individualPrice;
    }
    public UpdateOrderItemForm()
    {
        
    }
}
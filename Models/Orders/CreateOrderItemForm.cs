namespace MyApplication.Models.Orders;

//This is the model to be bound to creation forms
// Additional validation / parameters could be associated directly with creates.
public class CreateOrderItemForm
{
    public int Id { get; set; }
    public OrderLineTypes LineType { get; set; }
    public string Details { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public double IndividualPrice { get; set; }
    public double TotalPrice => Quantity * IndividualPrice;
    
}
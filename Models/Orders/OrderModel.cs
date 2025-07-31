using System.ComponentModel.DataAnnotations;

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
    public double IndividualPrice { get; set; }
    public double TotalPrice => Quantity * IndividualPrice;
    
    public OrderItemModel(int id, OrderLineTypes lineType, string details, int quantity, double individualPrice)
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
    
    //For searching on
    public override string ToString()
    {
        return $"Id: {Id}, LineType: {LineType}, Details: {Details}, Quantity: {Quantity}, IndividualPrice: {IndividualPrice:C}, TotalPrice: {TotalPrice:C}";
    }

    
}

public enum OrderLineTypes
{
    //Using this custom attribute for displaying enums in the UI easily.
    [Display(Name = "Repair Window")]
    RepairWindow,
    
    [Display(Name = "Install Dehumidifier")]
    InstallDehumidifier,
    
    [Display(Name = "Install Door Locks")]
    InstallDoorLocks,
    
    [Display(Name = "Install Fan")]
    InstallFan,
    
    [Display(Name = "Paint Room")]
    PaintRoom,
    
    [Display(Name = "Install Flooring")]
    InstallFlooring,
    
    [Display(Name = "Repair Plumbing")]
    RepairPlumbing
}
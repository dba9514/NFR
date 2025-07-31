using MyApplication.Models.Orders;

namespace MyApplication.Utilities;

public static class MockData
{
    public static List<OrderModel> Orders { get; set; } = new()
    {
        new OrderModel()
        {
            Id = Guid.NewGuid(),
            OrderNumber = 1234,
            Items = new List<OrderItemModel>
            {
                new OrderItemModel(
                    id: 1,
                    lineType: OrderLineTypes.RepairWindow,
                    details: "24 inches by 48 inches in the second floor bedroom",
                    quantity: 1,
                    individualPrice: 150.00
                ),
                new OrderItemModel(
                    id: 2,
                    lineType: OrderLineTypes.InstallDehumidifier,
                    details: "Laundry room",
                    quantity: 1,
                    individualPrice: 100.00
                ),
                new OrderItemModel(
                    id: 3,
                    lineType: OrderLineTypes.InstallDoorLocks,
                    details: "Kitchen and front door locks were missing",
                    quantity: 2,
                    individualPrice: 75.00
                ),
                
            }
        },
        
        new OrderModel()
        {
            Id = Guid.NewGuid(),
            OrderNumber = 5678,
            Items = new List<OrderItemModel>
            {
                new OrderItemModel(
                    id: 4,
                    lineType: OrderLineTypes.InstallFan,
                    details: "Living room fan installation model# G5544FC",
                    quantity: 1,
                    individualPrice: 200.00
                ),
                new OrderItemModel(
                    id: 5,
                    lineType: OrderLineTypes.PaintRoom,
                    details: "Painting the guest bedroom with blue color",
                    quantity: 1,
                    individualPrice: 180.00
                ),
                new OrderItemModel(
                    id: 6,
                    lineType: OrderLineTypes.InstallFlooring,
                    details: "Laminate plank flooring in the hallway",
                    quantity: 3,
                    individualPrice: 50.00 // per unit
                ),
                new OrderItemModel(
                    id: 7,
                    lineType: OrderLineTypes.RepairPlumbing,
                    details: "Replace pea trap and garbage disposal.",
                    quantity: 1,
                    individualPrice: 120.00
                ),
            }
        }

    };
}
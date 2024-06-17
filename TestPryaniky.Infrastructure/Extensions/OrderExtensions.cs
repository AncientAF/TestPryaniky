namespace TestPryaniky.Infrastructure.Extensions;

public static class OrderExtensions
{
    public static void Update(this Order order, Order updatedOrder)
    {
        order.OrderItems = updatedOrder.OrderItems;
        order.Address = updatedOrder.Address;
        order.Phone = updatedOrder.Phone;
        order.Status = updatedOrder.Status;
    }
}
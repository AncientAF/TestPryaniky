namespace TestPryaniky.Application.Extensions;

public static class OrderItemExtensions
{
    public static List<OrderItem> ToOrderItemList(this List<(Guid productId, int quantity)> items, Guid orderId)
    {
        return items.Select(l => new OrderItem
        {
            OrderId = orderId,
            Quantity = l.quantity,
            ProductId = l.productId
        }).ToList();
    }
}
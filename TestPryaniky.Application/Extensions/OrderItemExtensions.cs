using TestPryaniky.Application.Orders;

namespace TestPryaniky.Application.Extensions;

public static class OrderItemExtensions
{
    public static List<OrderItem> ToOrderItemList(this List<ProductIdWithQuantity> items, Guid orderId)
    {
        return items.Select(l => new OrderItem
        {
            OrderId = orderId,
            Quantity = l.Quantity,
            ProductId = l.ProductId
        }).ToList();
    }
}